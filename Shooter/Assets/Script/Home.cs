using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public GameObject helpGameObject;
    public GameObject loading;
    public void Start()
    {
        helpGameObject.SetActive(false);
    }

    public void StartButton()
    {
        loading.SetActive(true);
        SceneManager.LoadScene("MainGame");
    }

    public void ReMain()
    {
        SceneManager.LoadScene("Title");
    }
    public void HelpButton()
    {
        helpGameObject.SetActive(true);
    }

    public void CloseHelp()
    {
        helpGameObject.SetActive(false);
    }
}
