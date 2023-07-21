using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGplayer2Movement : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    [SerializeField] private float moveSpeed;
    private float h;
    private bool isShoting;
    [SerializeField] GameObject bullet;
    private int lastH;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !isShoting)
            Attack();

        if(!isShoting)
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                h = 0;
            else if (Input.GetKey(KeyCode.A))
                h = -1;
            else if (Input.GetKey(KeyCode.D))
                h = 1;
            else
                h = 0;
        }

        if (h != 0)
        {
            anim.SetBool("isWalk", true);
            transform.localScale = new Vector3(h, 1, 1);
            lastH = (int)h;
        }
        else
            anim.SetBool("isWalk", false);
    }

    public void StopWalk()
    {
        anim.SetBool("isWalk", false);
    }

    private void Attack()
    {
        h = 0;
        isShoting = true;
        Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<PGbullet>().dir = lastH;
        anim.SetTrigger("shot");
        StartCoroutine(DelayAttack());
    }

    IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(0.6f);
        isShoting = false;
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(h * moveSpeed * Time.deltaTime, rigid.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndPortal"))
            GameManager.GameChange();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("PGenemy"))
            GameManager.SceneReload(3);
    }
}
