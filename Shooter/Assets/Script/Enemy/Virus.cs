using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : Enemy
{
    public GameObject virusBullet;

    public float delay;
    public float mxDelay;

    void Update()
    {
        Move();
        Fire();
    }

    void Fire()
    {
        delay += Time.deltaTime;

        if (delay >= mxDelay)
        {
            
            Instantiate(virusBullet, transform.position, transform.rotation);
            delay = 0;
        }
    } 
    public void Start()
    {
        var plr = GameObject.FindWithTag("Player").GetComponent<Player>();
        plr.iMoster += 1;
    }
    void Move()
    {
        
        
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        
        Player play = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (gameObject.transform.position.y < -4.9)
        {
            Debug.Log("발동");
            play.fain += 5;
            Destroy(gameObject);
        }
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
            case "Player":
                Destroy(gameObject);
                break;
        }

        if (health <= 0)
        {
            var pl = GameObject.FindWithTag("Player").GetComponent<Player>();
            pl.iMoster -= 1;
            Score scoreManager = GameObject.FindWithTag("Score").GetComponent<Score>();
            scoreManager.score += 200;
            Destroy(gameObject);
        }
    }    

}
