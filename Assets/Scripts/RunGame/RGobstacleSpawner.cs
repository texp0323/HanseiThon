using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGobstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    [SerializeField] float summonDealy;
    [SerializeField] GameObject endPortal;

    private void Start()
    {
        StartCoroutine(summonObstacle());
    }

    IEnumerator summonObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(summonDealy, summonDealy + 1.5f));
            while (true) 
            {
                if(GameManager.RGend)
                {
                    break;
                }
                int rand = Random.Range(0, obstacles.Length);
                if (!obstacles[rand].activeSelf)
                {
                    obstacles[rand].GetComponent<RGobstacle>().ResetLifeTime();
                    obstacles[rand].transform.position = transform.position;
                    obstacles[rand].SetActive(true);
                    break;
                }
            }
            if (GameManager.RGend)
            {
                endPortal.GetComponent<RGobstacle>().ResetLifeTime();
                endPortal.transform.position = transform.position;
                endPortal.SetActive(true);
                break;
            }
        }
    }
}
