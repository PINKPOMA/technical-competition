using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spowner : MonoBehaviour
{
    public GameObject[] spownPosition;
    public GameObject[] Monster;
    public GameObject big1;

    public float Monsterspondelay;
    public float mxMonsterspon;
    
    public float rbcSpown;
    public float mxrbcSpown;
    
    public float wbcSpown;
    public float mxwbcSpown;

    public int RBCRandom;
    public int WBCRandom;
    public int DefaultRandom;
    public int DefaultMonsterRandom;
    public void Update()
    {
        RBC();
        DefaultSpown();
        WBC();
    }

    void WBC()
    {
        wbcSpown += Time.deltaTime;
        if (wbcSpown >= mxwbcSpown)
        {
            WBCRandom = Random.Range(0, 5);
            big1 = Instantiate(Monster[5], spownPosition[WBCRandom].transform.position,
                spownPosition[WBCRandom].transform.rotation);
            wbcSpown = 0;
        }
        mxwbcSpown = Random.Range(1f, 2f);
    }

    void DefaultSpown()
    {
        Monsterspondelay += Time.deltaTime;
        if (Monsterspondelay >= mxMonsterspon)
        {
            DefaultRandom = Random.Range(0, 5);
            DefaultMonsterRandom = Random.Range(0, 4);
            big1 = Instantiate(Monster[DefaultMonsterRandom], spownPosition[DefaultRandom].transform.position,
                spownPosition[DefaultRandom].transform.rotation);
            Monsterspondelay = 0;
        }
        
        mxMonsterspon = Random.Range(2f,4f);
    }

    void RBC()
    {
        rbcSpown += Time.deltaTime;
        if (rbcSpown >= mxrbcSpown)
        {
            RBCRandom = Random.Range(0, 4);
            big1 = Instantiate(Monster[4], spownPosition[RBCRandom].transform.position,
                spownPosition[RBCRandom].transform.rotation);
            rbcSpown = 0;
        }
        
        
        mxwbcSpown = Random.Range(13f, 15f);
    }
}
