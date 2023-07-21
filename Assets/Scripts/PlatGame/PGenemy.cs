using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGenemy : MonoBehaviour
{
    public int enemyType;
    [SerializeField] bool isBoss;

    SpriteRenderer spr;
    Animator anim;
    Rigidbody2D rigid;

    [SerializeField] private int hp;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
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
        spr.color = Color.red;
        Invoke("hitColorEnd", 0.1f);
        if(isBoss)
        {
            if(Random.Range(0, 2) == 0)
            {
                anim.SetTrigger("change");
                if(enemyType == 1)
                    enemyType = 0;
                else if(enemyType == 0)
                    enemyType = 1;
            }
        }
        if (hp <= 0)
            Destroy(gameObject);
    }

    private void hitColorEnd()
    {
        spr.color = Color.white;
    }
}
