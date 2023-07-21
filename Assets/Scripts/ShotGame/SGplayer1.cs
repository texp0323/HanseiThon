using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGplayer1 : MonoBehaviour
{

    private float h;

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            h = 0;
        else if (Input.GetKey(KeyCode.A))
            h = -1;
        else if(Input.GetKey(KeyCode.D))
            h = 1;
        else
            h = 0;

        if(transform.position.x > -5.3f && transform.position.x < 5.3f)
        {
            transform.Translate(h * Time.deltaTime * 8, 0, 0);
        }
        if(transform.position.x <= -5.3f)
        {
            transform.position = new Vector2(-5.2f, -4);
        }
        if (transform.position.x >= 5.3f)
        {
            transform.position = new Vector2(5.2f, -4);
        }
        transform.position = new Vector2(transform.position.x, -4);
    }
}
