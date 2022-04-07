using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg : MonoBehaviour
{
     public GameObject Back12;
     public GameObject Back13;
     
     public void OnBecameVisible()
     {
         Back12.transform.position = new Vector3(0, 5.79f, 0);
         Back13.transform.position = new Vector3(0, 26f, 0);
     }
}
