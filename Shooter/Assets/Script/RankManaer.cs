using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RankManaer : MonoBehaviour
{
    public Text ShowRank;
    public GameObject inputName;
    public InputField nametext;
    public bool sort;

    public string sname;
    public void EndOfName()
    {
        var scoreMaster = GameObject.FindWithTag("Score").GetComponent<Score>();
        if (!scoreMaster.setScore)
        {
            inputName.SetActive(false);
        }
        sname = nametext.text;

        
        scoreMaster.readerBoardScore[4] = scoreMaster.score;
        scoreMaster.readerBoardName[4] = sname;
        inputName.SetActive(false);
    }

    public void Update()
    {
        lder();
    }

    void lder()
    {
            var scoreMaster = GameObject.FindWithTag("Score").GetComponent<Score>();
            ShowRank.text = "리더보드\n\n" + scoreMaster.readerBoardName[0] + "(" +
                            scoreMaster.readerBoardScore[0] + ")\n" + scoreMaster.readerBoardName[1] + "(" +
                            scoreMaster.readerBoardScore[1] + ")\n" + scoreMaster.readerBoardName[2] + "(" +
                            scoreMaster.readerBoardScore[2] + ")\n" + scoreMaster.readerBoardName[3] + "(" +
                            scoreMaster.readerBoardScore[3] + ")\n" + scoreMaster.readerBoardName[4] + "(" +
                            scoreMaster.readerBoardScore[4] + ")\n";  
 
    }
    public void Exit()
    {        
        var sc = GameObject.FindWithTag("Score").GetComponent<Score>();
        SceneManager.LoadScene("Title");
        sc.setScore = false;
        sc.rank = 0;
        sc.score = 0;
    }
}
