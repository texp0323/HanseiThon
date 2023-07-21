using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGbrick : MonoBehaviour
{
    SpriteRenderer spr;

    public int brickHp;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage()
    {
        brickHp -= 1;
        spr.color = new Color(1, 1, 1, spr.color.a / 2);
        if(brickHp <= 0)
            Destroy(gameObject);
    }
}
