using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Covid : Enemy
{

    public GameObject bulletA;
    public GameObject bulletB;
    public GameObject Monster;
    public GameObject skill;
    public GameObject skill2;
    public GameObject fakemob;
    public GameObject player;
    public GameObject aqc;


    public Text covidHp;
    public Text covidpHp;

    public float attackDelay;
    public float mxAttackDelay;
    public int randomAttack;

    private void Update()
    {
        if (gameObject.transform.position.y > 3.6)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        Attack();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.name)
        {
            case "PlayerBulletA(Clone)":
                health -= 1;
                Destroy(col.gameObject);
                break;
            case "PlayerBulletB(Clone)":
                health -= 2;
                Destroy(col.gameObject);
                break;
        }

        if (health <= 0)
        {
            if(gameObject.name == "Covid")
            {
                var plrmanager = player.GetComponent<Player>();
                aqc.SetActive(true);
                Invoke("Qa", 2f);
                plrmanager.stage2On = true;
                plrmanager.health = 100;
                plrmanager.fain = 30;
                plrmanager.st1On = false;
                plrmanager.bossDelay = 0;
            }
            else
            {
                SceneManager.LoadScene("Clear");
            }
            Destroy(gameObject);
        }
    }

    void Qa()
    {
        aqc.SetActive(false);
    }
    void Attack()
    {
        attackDelay += Time.deltaTime;

        if (attackDelay >= mxAttackDelay)
        {
            randomAttack = Random.Range(1, 6);

            switch (randomAttack)
            {
                case 1:
                    if (gameObject.name == "Covid")
                    {
                        Flower();
                        attackDelay = 0;
                    }
                    else
                    {
                        FlowerP();
                        attackDelay = 0;
                    }
                    break;
                case 2:
                    if (gameObject.name == "Covid")
                    {
                        Sp();
                        attackDelay = 0;
                    }
                    else
                    {
                        SpP();
                        attackDelay = 0;
                    }
                    break;
                case 3:               
                    if (gameObject.name == "Covid")
                    {
                        Water();
                        attackDelay = 0;
                    }
                    else
                    {
                        Waterp();
                        attackDelay = 0;
                    }
                    break;
                case 4:          
                    if (gameObject.name == "Covid")
                    {
                        ShootGun();
                        attackDelay = 0;
                    }
                    else
                    {
                        ShootGunP();
                        attackDelay = 0;
                    }
                    break;
                case 5:
                    FakeWBC();
                    attackDelay = 0;
                    break;
            }
        }
    }

    void FakeWBC()
    {
        Instantiate(fakemob, new Vector3(0, 2, 0), transform.rotation);
    } 
    void Sp()
    {
        Instantiate(Monster, new Vector3(0, 2, 0), transform.rotation);
    }

    void SpP()
    {
        Instantiate(Monster, new Vector3(2, 2, 0), transform.rotation);
        Instantiate(Monster, new Vector3(-2, 2, 0), transform.rotation);
    }
void Flower()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, i * 45));
        }
    }

    void FlowerP()
    {
        for (int i = 0; i < 16; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, i * 22));
        }
        Invoke("Flower", 0.5f);
    }

    void ShootGun()
    {
        Instantiate(skill, new Vector3(-4, 1.9f, 0), transform.rotation);
        Instantiate(skill, new Vector3(-2, 0, 0), transform.rotation);
        Instantiate(skill, new Vector3(2, 0f, 0), transform.rotation);
        Instantiate(skill, new Vector3(4, 1.9f, 0), transform.rotation);
    }
    
    void ShootGunP()
    {
        Instantiate(skill2, new Vector3(-4, 1.9f, 0), transform.rotation);
        Instantiate(skill2, new Vector3(-2, 0, 0), transform.rotation);
        Instantiate(skill2, new Vector3(2, 0f, 0), transform.rotation);
        Instantiate(skill2, new Vector3(4, 1.9f, 0), transform.rotation);
    }

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    void Water()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, i * 45));
        }
        Invoke("Water1", 0.3f);
    }
    void Water1()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 2 +(i * 45)));
        }
        Invoke("Water2", 0.3f);
    }
    void Water2()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 4 +(i * 45)));
        }
        Invoke("Water3", 0.3f);
    }
    void Water3()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 6 +(i * 45)));
        }
        Invoke("Water4", 0.3f);
    }
    void Water4()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 8 +(i * 45)));
        }
        Invoke("Water5", 0.3f);
    }
    void Water5()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 10 +(i * 45)));
        }
        Invoke("Water6", 0.3f);
    }
    void Water6()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 12 +(i * 45)));
        }
        Invoke("Water7", 0.3f);
    }
    void Water7()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 14 +(i * 45)));
        }
        Invoke("Water8", 0.3f);
    }
    void Water8()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 16 +(i * 45)));
        }
        Invoke("Water9", 0.3f);
    }
    void Water9()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 18 +(i * 45)));
        }
        Invoke("Water10", 0.3f);
    }
    void Water10()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 20 +(i * 45)));
        }
        Invoke("Water11", 0.3f);
    }
    void Water11()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 22 +(i * 45)));
        }
        Invoke("Water12", 0.3f);
    }
    void Water12()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 24 +(i * 45)));
        }
        Invoke("Water13", 0.3f);
    }
    void Water13()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 26 +(i * 45)));
        }
        Invoke("Water14", 0.3f);
    }
    void Water14()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 28 +(i * 45)));
        }
        Invoke("Water15", 0.3f);
    }
    void Water15()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 30 +(i * 45)));
        }
        Invoke("Water16", 0.3f);
    }
    void Water16()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 32 +(i * 45)));
        }
        Invoke("Water17", 0.3f);
    }
    void Water17()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 34 +(i * 45)));
        }
        Invoke("Water18", 0.3f);
    }
    void Water18()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 36 +(i * 45)));
        }
        Invoke("Water19", 0.3f);
    }
    void Water19()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 38 +(i * 45)));
        }
        Invoke("Water20", 0.3f);
    }
    void Water20()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletA, transform.position, Quaternion.Euler(0, 0, 40 +(i * 45)));
        }
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    void Waterp()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, i * 45));
        }
        Invoke("Waterp1", 0.3f);
        Invoke("Water", 2f);
    }
    void Waterp1()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 2 +(i * 45)));
        }
        Invoke("Waterp2", 0.3f);
        Invoke("Water", 2f);
    }
    void Waterp2()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 4 +(i * 45)));
        } 
        Invoke("Waterp3", 0.3f);
        
        Invoke("Water", 2f);
    }
    void Waterp3()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 6 +(i * 45)));
        }
        Invoke("Waterp4", 0.3f);
    }
    void Waterp4()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 8 +(i * 45)));
        }
        Invoke("Waterp5", 0.3f);
    }
    void Waterp5()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 10 +(i * 45)));
        }
        Invoke("Waterp6", 0.3f);
    }
    void Waterp6()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 12 +(i * 45)));
        }
        Invoke("Waterp7", 0.3f);
    }
    void Waterp7()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 14 +(i * 45)));
        }
        Invoke("Waterp8", 0.3f);
    }
    void Waterp8()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 16 +(i * 45)));
        }
        Invoke("Waterp9", 0.3f);
    }
    void Waterp9()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 18 +(i * 45)));
        }
        Invoke("Waterp10", 0.3f);
    }
    void Waterp10()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 20 +(i * 45)));
        }
        Invoke("Waterp11", 0.3f);
    }
    void Waterp11()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 22 +(i * 45)));
        }
        Invoke("Waterp12", 0.3f);
    }
    void Waterp12()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 24 +(i * 45)));
        }
        Invoke("Waterp13", 0.3f);
    }
    void Waterp13()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 26 +(i * 45)));
        }
        Invoke("Waterp14", 0.3f);
    }
    void Waterp14()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 28 +(i * 45)));
        }
        Invoke("Waterp15", 0.3f);
    }
    void Waterp15()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 30 +(i * 45)));
        }
        Invoke("Waterp16", 0.3f);
    }
    void Waterp16()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 32 +(i * 45)));
        }
        Invoke("Waterp17", 0.3f);
    }
    void Waterp17()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 34 +(i * 45)));
        }
        Invoke("Waterp18", 0.3f);
    }
    void Waterp18()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 36 + (i * 45)));
        }

        Invoke("Waterp19", 0.3f);
    }
    void Waterp19()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 38 +(i * 45)));
        }
        Invoke("Waterp20", 0.3f);
    }
    void Waterp20()
    {
        for (int i = 0; i < 8; i++)
        {
            Instantiate(bulletB, transform.position, Quaternion.Euler(0, 0, 40 +(i * 45)));
        }
    }
}
