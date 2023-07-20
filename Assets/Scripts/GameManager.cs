using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public int gameNumber = 1;
    static public int RGscore = 0;
    static public Text RGscoreText;
    static public bool RGend = false;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if(gameNumber == 1)
        {
            RGscoreText = GameObject.FindWithTag("RGscoreText").GetComponent<Text>();
            RGscoreText.text = "SCORE: " + RGscore;
        }
    }
    static public void SceneReload(int a)
    {
        RGend = false;
        RGscore = 0;
        SceneManager.LoadScene(a);
    }
    static public void GameChange()
    {
        if (gameNumber == 1) 
        {
            gameNumber = 2;
            SceneManager.LoadScene(2);
        }
        else if(gameNumber == 2)
        {
            gameNumber = 3;
            SceneManager.LoadScene(3);
        }
        else if(gameNumber == 3)
        {
            SceneManager.LoadScene(4);
        }
    }
    static public void RGscoreUp()
    {
        RGscore++;
        RGscoreText.text = "SCORE: " + RGscore;
        if(RGscore >= 30)
            RGend = true;
    }

}
