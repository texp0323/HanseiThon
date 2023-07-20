using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGbullet : MonoBehaviour
{
    [SerializeField] private int bulletType;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask hitLayer;
    public int dir;

    private void Start()
    {
        transform.localScale = new Vector3(dir, 1,1);
        Destroy(gameObject, 1f);
    }

    private void Update()
    {
        transform.Translate(new Vector3(dir, 0, 0) * Time.deltaTime * speed);
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0.1f, hitLayer);
        if (hit)
        {
            if (hit.transform.CompareTag("PGenemy"))
            {
                if (hit.transform.GetComponent<PGenemy>().enemyType == bulletType)
                    hit.transform.GetComponent<PGenemy>().TakeDam(1);
            }
            Destroy(gameObject);
        }
    }
}
