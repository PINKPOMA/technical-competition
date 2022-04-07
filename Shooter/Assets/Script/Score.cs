using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{ 
    public static Score Instance;
    public Text scoreText;
    
    public int score;
    public int rank;
    public int temp;
    public string temps;

    public bool setScore;
    
    public int[] readerBoardScore = new []{0,0,0,0,0};
    public string[] readerBoardName = new []{" "," "," "," "," "};
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {Application.Quit();}
        if (SceneManager.GetActiveScene().name == "MainGame")
        {
            scoreText = GameObject.FindWithTag("Stext").GetComponent<Text>();
            scoreText.text = score + "점";
        }
        if (readerBoardScore[4] < score)
        {
            setScore = true;
            for (int i = 0; i < 5; i++)
            {
                if (readerBoardScore[i] < score)
                {
                    rank = i;
                    break;
                }
            }
        }
        ChangeRank();
    }

    void ChangeRank()
    {
        for (int i = 4; i > 0; i--)
        {
            if (readerBoardScore[i] > readerBoardScore[i - 1])
            {
                temp = readerBoardScore[i];
                readerBoardScore[i] = readerBoardScore[i - 1];
                readerBoardScore[i - 1] = temp;

                temps = readerBoardName[i];
                readerBoardName[i] = readerBoardName[i - 1];
                readerBoardName[i - 1] = temps;
            }

        }
    }
}
