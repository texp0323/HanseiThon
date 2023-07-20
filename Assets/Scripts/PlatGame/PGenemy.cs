using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGenemy : MonoBehaviour
{
    public int enemyType;
    [SerializeField] bool isBoss;

    Animator anim;
    Rigidbody2D rigid;

    [SerializeField] private int hp;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(-75 * Time.deltaTime, rigid.velocity.y);
    }

    public void TakeDam(int damage)
    {
        hp -= damage;
        if(isBoss)
        {
            if(Random.Range(0, 2) == 0)
                anim.SetTrigger("change");
        }
        if (hp <= 0)
            Destroy(gameObject);
    }
}
