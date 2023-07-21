using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public int gameNumber = 0;
    static public int RGscore = 0;
    static public Text RGscoreText;
    static public bool RGend = false;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (gameNumber == 1)
        {
            RGscoreText = GameObject.FindWithTag("RGscoreText").GetComponent<Text>();
            RGscoreText.text = "SCORE: " + RGscore;
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
