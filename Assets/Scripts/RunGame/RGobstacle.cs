using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGobstacle : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lifeTime;
    private float curlifeTime;


    public void ResetLifeTime()
    {
        curlifeTime = lifeTime;
    }
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if(curlifeTime > 0)
            curlifeTime -= Time.deltaTime;
        else
            gameObject.SetActive(false);
    }
}
