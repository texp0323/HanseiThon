using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGbullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private LayerMask hitLayer;
    void Update()
    {
        transform.Translate(Vector2.down * bulletSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0.1f, hitLayer);
        if(hit)
        {
            if (hit.transform.CompareTag("RGenemy"))
            {
                hit.transform.gameObject.SetActive(false);
                GameManager.RGscoreUp();
            }
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector2.right * 0.1f);
    }

}
