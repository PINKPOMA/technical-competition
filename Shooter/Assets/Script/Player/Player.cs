

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health;
    public int speed;
    public int fain;
    public int power;
    public int iMoster;

    public bool noEnemyCheatOn;
    public bool stage2On;
    public bool damageUpOn;
    public bool shildOn;
    public bool damaged;
    public bool st1On;
    public bool st2On;
    public bool AllDes;
    
    public float shootDelay;
    public float ShidD;
    public float mxShootDelay;
    public float damageUpDelay;
    public float mxDamageUpDelay;
    public float shildDelay;
    public float mxShildDelay;
    public float damagedDelay;
    public float mxdamagedDelay;
    public float bossDelay;
    public float mxbossDelay;
    
    public GameObject bullet;
    public GameObject spowner;
    public GameObject upgreadBullet;
    public GameObject covidPlus;
    public GameObject covid;
    public GameObject rbc;
    public GameObject wbc;
    public GameObject sshild;
    public GameObject sound1;
    public GameObject sound2;
    public GameObject sound3;   
    public GameObject ac;
    public GameObject acc;
    public GameObject bg1;
    public GameObject bg2;

    public Text hpText;
    public Text fainText;
    public Text stageText;
    public Text powerText;
    public Text shildText;
    public Text bosshptext1;
    public Text bosshptext2;
    public Text BsnameText1;
    public Text BsnameText2;
    public Text ShidText;

    public SpriteRenderer rander;



    private void Awake()
    {
        bosshptext1.gameObject.SetActive(false);
        bosshptext2.gameObject.SetActive(false);
        BsnameText1.gameObject.SetActive(false);
        BsnameText2.gameObject.SetActive(false);
        ShidText.gameObject.SetActive(false);
        covid.gameObject.SetActive(false);
        covidPlus.gameObject.SetActive(false);
        rander = gameObject.GetComponent<SpriteRenderer>();
    }
    
    public void st1()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void st2()
    {
        Destroy(covid);
        stage2On = true;
    }
    public void rbcsp()
    {
        Instantiate(rbc, Vector3.up, transform.rotation);
    }
    public void wbcsp()
    {
        Instantiate(wbc, Vector3.up, transform.rotation);
    }
    public void Up()
    {
        power++;
        if (power > 5)
        {
            power = 5;
        }
    }

    public void AllDestroyd()
    {
        Destroy(GameObject.FindWithTag("Enemy"));
        if (st1On)
        {
            var cvd = covid.GetComponent<Covid>();
            cvd.health -= 9999;
        }

        if (st2On)
            SceneManager.LoadScene("Clear");
    }


    public void Down()
    {
        power--;
        if (power < 1)
        {
            power = 1;
        }
    }

    public void pHp()
    {
        health += 10;
        if (health > 100)
        {
            health = 100;
        }
    }
    public void mHp()
    {
        health -= 10;
    }
    
    public void pfain()
    {
        fain += 10;
    }
    public void mfain()
    {
        fain -= 10;
        if (fain < 0)
        {
            fain = 0;
        }
    }
    public void OnNoDamage()
    {
        noEnemyCheatOn = true;
        
        rander.color = new Color(0.5f, 0.75f, 1,1f);
    }
    
    public void OffNoDamage()
    {
        noEnemyCheatOn = false;
        rander.color = new Color(1, 1, 1,1);
    }
    void Update()
    {
        spCheck();
        Death();
        Move();
        Shoot();
        Defense();
        InfoBar();
        DamageUp();
        NoEnemy();
        Damaged();
        CallBoss();
        
    }


    

    void spCheck()
    {
        if (stage2On && !st2On)
        {
            spowner.SetActive(true);
        }
    } 
    void CallBoss()
    {
        bossDelay += Time.deltaTime;

        if (bossDelay >= mxbossDelay)
        {
            spowner.SetActive(false);
            if (stage2On)
            {
                st2On = true;
                covidPlus.gameObject.SetActive(true);
            }
            else
            {
                st1On = true;
                covid.gameObject.SetActive(true);
            }
                
        }
    }
    void Damaged()
    {
        if (damaged)
        {
            damagedDelay += Time.deltaTime;
        }

        if (damagedDelay >= mxdamagedDelay)
        {
            damaged = false;
            if (!noEnemyCheatOn)
            {
                rander.color = new Color(1, 1, 1,1);
            }
            damagedDelay = 0;
        }
    }
    void NoEnemy() // 무적 아이템과 쉴드 아이템
    {
        if (shildOn)
        {
            shildDelay += Time.deltaTime;
        }

        if (shildDelay >= mxShildDelay && !noEnemyCheatOn)
        {
            shildDelay = 0;
            shildOn = false;
            sshild.SetActive(false);
            rander.color = new Color(1, 1, 1,1);
        }
    }
    void DamageUp() // 데미지 업 아이템
    {
        if (damageUpOn)
        {
            damageUpDelay += Time.deltaTime;
            if (damageUpDelay >= mxDamageUpDelay)
            {
                damageUpDelay = 0;
                damageUpOn = false;
            }
        }
    }

    void Death() // 사망처리
    {
        if (health > 100)
            health = 100;
        if (fain < 0)
            fain = 0;
        if (power > 5)
            power = 5;
        if (health <= 0 || fain >= 100)
        {
            var scoreComponent = GameObject.FindWithTag("Score").GetComponent<Score>();
            if (scoreComponent.setScore)
            {
                SceneManager.LoadScene("Rank");
            }
            else 
                SceneManager.LoadScene("GameOver");
        }
    }
    void InfoBar()
    {
        hpText.text = "Hp: " + health;
        fainText.text = "Pain: " + fain;
        if (stage2On)
        {
            stageText.text = "Stage 2";
        }
        else
        {
            stageText.text = "Stage 1";
        }

        powerText.text = power.ToString();
        if (noEnemyCheatOn)
        {
            shildText.text = "On";
        }

        if (!noEnemyCheatOn)
        {
            shildText.text = "Off";
        }

        if (shildOn)
        {
            ShidD -= Time.deltaTime;
            ShidText.gameObject.SetActive(true);
            ShidText.text = (ShidD).ToString();
        }
        else
        {
            ShidText.gameObject.SetActive(false);
            ShidD = 3;
        }
        if (st1On)
        {
            ac.SetActive(false);
            sound1.SetActive(true);
            bosshptext1.gameObject.SetActive(true);
            BsnameText1.gameObject.SetActive(true);
            var cvd = covid.GetComponent<Covid>();
            bosshptext1.text = cvd.health.ToString();
        }
        if(stage2On)
        {
            bg1.SetActive(false);
            bg2.SetActive(true);
            sound1.SetActive(false);
            sound2.SetActive(true);
            bosshptext1.gameObject.SetActive(false);
            BsnameText1.gameObject.SetActive(false);
        }

        if (st2On)
        {         
            sound2.SetActive(false);
            sound3.SetActive(true);
            bosshptext2.gameObject.SetActive(true);
            BsnameText2.gameObject.SetActive(true);
            var cvdp = covidPlus.GetComponent<Covid>();
            bosshptext2.text = cvdp.health.ToString();
        }
        else
        {
            bosshptext2.gameObject.SetActive(false);
            BsnameText2.gameObject.SetActive(false);
        }
    }

    void OffSound()
    {
        acc.SetActive(false);
    }
    void Shoot()
    {
        shootDelay += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && shootDelay >= mxShootDelay)
        {
            acc.SetActive(true);
            Invoke("OffSound", 1f);
            if (damageUpOn)
            {
                switch (power)
                {
                    case 1:
                        Instantiate(upgreadBullet,
                            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y +  0.5f, 0),
                            transform.rotation);
                        break;
                    case 2:
                        Instantiate(upgreadBullet,
                            new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y,
                                0),
                            transform.rotation);
                        Instantiate(upgreadBullet,
                            new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y,
                                0),
                            transform.rotation);
                        break;
                    case 3:
                        Instantiate(upgreadBullet,
                            new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y,
                                0),
                            transform.rotation);
                        Instantiate(upgreadBullet,
                            new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y,
                                0),
                            transform.rotation);
                        Instantiate(upgreadBullet,
                            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y +  0.5f, 0),
                            transform.rotation);
                        break;
                    case 4:
                        Instantiate(upgreadBullet,
                            new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y ,
                                0),
                            transform.rotation);
                        Instantiate(upgreadBullet,
                            new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y ,
                                0),
                            transform.rotation);
                        Instantiate(upgreadBullet,
                            new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y -0.5f, 0),
                            transform.rotation);
                        Instantiate(upgreadBullet,
                            new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y - 0.5f, 0),
                            transform.rotation);
                        break;
                    case 5:
                        Instantiate(upgreadBullet,
                            new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y ,
                                0),
                            transform.rotation);
                        Instantiate(upgreadBullet,
                            new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y ,
                                0),
                            transform.rotation);
                        Instantiate(upgreadBullet,
                            new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y - 0.5f, 0),
                            transform.rotation);
                        Instantiate(upgreadBullet,
                            new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y - 0.5f, 0),
                            transform.rotation);
                        Instantiate(upgreadBullet,
                            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y +  0.5f, 0),
                            transform.rotation);
                        break;
                }
            }
            else
            {
                switch (power)
                {
                    case 1:
                        Instantiate(bullet,
                            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, 0),
                            transform.rotation);
                        break;
                    case 2:
                        Instantiate(bullet,
                            new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y,
                                0),
                            transform.rotation);
                        Instantiate(bullet,
                            new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y,
                                0),
                            transform.rotation);
                        break;
                    case 3:
                        Instantiate(bullet,
                            new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y,
                                0),
                            transform.rotation);
                        Instantiate(bullet,
                            new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y,
                                0),
                            transform.rotation);
                        Instantiate(bullet,
                            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, 0),
                            transform.rotation);
                        break;
                    case 4:
                        Instantiate(bullet,
                            new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y,
                                0),
                            transform.rotation);
                        Instantiate(bullet,
                            new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y,
                                0),
                            transform.rotation);
                        Instantiate(bullet,
                            new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y - 0.5f, 0),
                            transform.rotation);
                        Instantiate(bullet,
                            new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y - 0.5f, 0),
                            transform.rotation);
                        break;
                    case 5:
                        Instantiate(bullet,
                            new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y,
                                0),
                            transform.rotation);
                        Instantiate(bullet,
                            new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y,
                                0),
                            transform.rotation);
                        Instantiate(bullet,
                            new Vector3(gameObject.transform.position.x + 1f, gameObject.transform.position.y - 0.5f, 0),
                            transform.rotation);
                        Instantiate(bullet,
                            new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y - 0.5f, 0),
                            transform.rotation);
                        Instantiate(bullet,
                            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, 0),
                            transform.rotation);
                        break;
                }
            }
            shootDelay = 0;
        }
    }
    

    void Defense()
    {
        if (transform.position.x <= -2.9)
        {
            gameObject.transform.position = new Vector3(-2.9f,transform.position.y, transform.position.z );
        }
        
        if (transform.position.x >= 2.9)
        {
            gameObject.transform.position = new Vector3(2.9f, transform.position.y, transform.position.z);
        }
        
        if (transform.position.y <= -4.3)
        {
            gameObject.transform.position = new Vector3(transform.position.x,-4.3f, transform.position.z );
        }
        
        if (transform.position.y >= 4.3)
        {
            gameObject.transform.position = new Vector3(transform.position.x, 4.3f, transform.position.z);
        }

    }
    void Move()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Item")
        {
            var objectname = col.gameObject.GetComponent<Item>();
            Item(objectname.type);
            Destroy(col.gameObject);
        }
        
        if (noEnemyCheatOn || shildOn || damaged)
        {
            return;
        }
        
        OnDamagd(col.name);
    }

    void Item(string itemName)
    {
        Score scoreManager = GameObject.FindWithTag("Score").GetComponent<Score>();
        switch (itemName)
        {
            case "DamageUp":
                scoreManager.score += 50;
                damageUpOn = true;
                break;
            case "Shild":
                scoreManager.score += 100;
                if (shildOn)
                {
                    shildDelay = 0;
                }
                else
                {
                    shildOn = true;
                    sshild.SetActive(true);
                    rander.color = new Color(1, 1, 1, 0.5f);
                }
                break;
            case "FainDown":
                scoreManager.score += 100;
                fain -= 25;
                break;
            case "Heal":
                scoreManager.score += 200;
                health += 30;
                break;
            case "WeponUpgread":
                scoreManager.score += 400;
                power += 1;
                break;
            case "Point":
                scoreManager.score += 2000;
                break;
        }
    }
    void OnDamagd(string enemyName)
    {
        switch (enemyName)
        {
            case "virus(Clone)":
                health -= 5;
                iMoster -= 1;
                damaged = true;
                rander.color = new Color(1, 1, 1,0.5f);
                break;
            case "cancer(Clone)":
                health -= 10;
                iMoster -= 1;
                damaged = true;
                rander.color = new Color(1, 1, 1,0.5f);
                break;
            case "Germ(Clone)":
                health -= 7;
                iMoster -= 1;
                damaged = true;
                rander.color = new Color(1, 1, 1,0.5f);
                break;
            case "Covid":
                health -= 5;
                damaged = true;
                rander.color = new Color(1, 1, 1,0.5f);
                break;
            case "CovidPlus":
                health -= 8;
                damaged = true;
                rander.color = new Color(1, 1, 1,0.5f);
                break;
            case "bacteria(Clone)":
                health -= 6;
                iMoster -= 1;
                damaged = true;
                rander.color = new Color(1, 1, 1,0.5f);
                break;
            case "CovidBullet(Clone)":
                health -= 10;
                damaged = true;
                rander.color = new Color(1, 1, 1,0.5f);
                break;
            case "CovidPlusBullet(Clone)":
                health -= 16;
                damaged = true;
                rander.color = new Color(1, 1, 1,0.5f);
                break;
            case "VirusBullet(Clone)":
                health -= 10;
                damaged = true;
                rander.color = new Color(1, 1, 1,0.5f);
                break;
            case "CancerBullet(Clone)":
                health -= 10;
                damaged = true;
                rander.color = new Color(1, 1, 1,0.5f);
                break;
        }
    }
}
