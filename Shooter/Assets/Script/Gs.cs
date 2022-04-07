using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gs : MonoBehaviour
{
    public void Awake()
    {
        gameObject.SetActive(true);
        Invoke("Move", 2f);
    }

    void Move()
    {
        gameObject.SetActive(false);
    }
}
