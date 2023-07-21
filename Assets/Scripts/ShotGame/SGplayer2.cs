using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGplayer2 : MonoBehaviour
{
    Animator anim;
    private bool shotAble = true;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shotAble)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                anim.Play("SGbar_1");
                shotAble = false;
                StartCoroutine(shotDelay());
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                anim.Play("SGbar_2");
                shotAble = false;
                StartCoroutine(shotDelay());
            }
        }
    }

    IEnumerator shotDelay()
    {
        yield return new WaitForSeconds(0.001f);
        shotAble = true;
    }
}
