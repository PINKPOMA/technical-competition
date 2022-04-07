using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip[] _Audio = new AudioClip[5];
    public AudioSource[] BGMAudioSource = new AudioSource[6];

    public bool inTitle;
    public bool inMainGame;
    public bool inEnding;


    public float titleMusic;
    public float mxtitleMusic;
    
    public float mainMusic;
    public float mxmainMusic;
    
    public float EndingMusic;
    public float mxEndingMusic;
    public void Update()
    {
        Sound();
    }

    void Sound()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            TitleSound();
        }
        else
        {
            BGMAudioSource[0].Stop();
        }
        
        if (SceneManager.GetActiveScene().name == "MainGame")
        {
            MainSound();
        }
        else
        {
            BGMAudioSource[1].Stop();
        }
        if (SceneManager.GetActiveScene().name == "Rank" || SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "Clear")
        {
            Ending();
        }
        else
        {
            BGMAudioSource[2].Stop();
        }
    }


    void Ending()
    {
        EndingMusic += Time.deltaTime;
        if (!inEnding)
        {
            BGMAudioSource[2].Play();
            inEnding = true;
        }

        if (inEnding && EndingMusic >= mxEndingMusic)
        {
            BGMAudioSource[2].Stop();
            inEnding = false;
            EndingMusic = 0;
        }
    }
    void MainSound()
    {
        mainMusic += Time.deltaTime;
        if (!inMainGame)
        {
            BGMAudioSource[1].Play();
            inMainGame = true;
        }

        if (inMainGame && mainMusic >= mxmainMusic)
        {
            BGMAudioSource[1].Stop();
            inMainGame = false;
            mainMusic = 0;
        }
    }

    void TitleSound()
    {
        titleMusic += Time.deltaTime;
        if (!inTitle)
        {
            BGMAudioSource[0].Play();
            inTitle = true;
        }

        if (inTitle && titleMusic >= mxtitleMusic)
        {
            BGMAudioSource[0].Stop();
            inTitle = false;
            titleMusic = 0;
        }
    }
}
