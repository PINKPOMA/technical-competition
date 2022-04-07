using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{
    public string type;
    public int speed;

    private void Update()
    {
        Move();
    }
    
    void Move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
