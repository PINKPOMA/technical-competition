using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int speed;
    
    public void OnBecameInvisible()
    {
        if (gameObject.transform.position.y < -4.3)
        {
            Destroy(gameObject);
        }
    }
}
