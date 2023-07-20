using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RG2p : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField] private float jumpPower;
    [SerializeField] private float delay;
    private bool jumpAble = true;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && jumpAble)
            Jump();
    }

    private void Jump()
    {
        jumpAble = false;
        Invoke(nameof(JumpEnd), delay);
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.up * jumpPower,ForceMode2D.Impulse);
    }

    private void JumpEnd()
    {
        jumpAble = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EndPortal"))
        {
            collision.gameObject.SetActive(false);
            GameManager.GameChange();
        }
        else
        {
            GameManager.SceneReload(1);
        }
    }
}
