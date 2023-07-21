using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public void MoveScene(int a)
    {
        GameManager.gameNumber = 1;
        SceneManager.LoadScene(a);
    }

    public void StopGame()
    {
        Application.Quit();
    }
}
