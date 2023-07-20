using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RG1p : MonoBehaviour
{
    [SerializeField] private GameObject[] bullets;
    private bool shotAble = true;

    void Update()
    {
        if(Input.GetKey(KeyCode.DownArrow) && shotAble)
            Shot();
    }

    private void Shot()
    {
        shotAble = false;
        StartCoroutine(ShotDelay());
        foreach(GameObject bullet in bullets)
        {
            if(!bullet.activeSelf)
            {
                bullet.SetActive(true);
                bullet.transform.position = transform.position;
                break;
            }
        }
    }

    IEnumerator ShotDelay()
    {
        yield return new WaitForSeconds(0.7f);
        shotAble = true;
    }
}
