using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGball : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector3 lastVelocity;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
    }
    private void Update()
    {
        lastVelocity = rigid.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Brick"))
        {
            collision.transform.GetComponent<SGbrick>().TakeDamage();
        }
        if (collision.transform.CompareTag("reloadWall"))
        {
            GameManager.SceneReload(2);
        }
        if (collision.transform.CompareTag("EndPortal"))
        {
            GameManager.GameChange();
        }
        Vector2 dir = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rigid.velocity = dir * 7;
    }
}
