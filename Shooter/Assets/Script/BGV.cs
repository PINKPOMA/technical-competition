using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGV : MonoBehaviour
{
    public void Update()
    {
        transform.Translate(Vector3.down * 5 * Time.deltaTime);
    }
}
