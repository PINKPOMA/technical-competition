using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : Enemy
{
    public GameObject germBullet;

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
            
            Instantiate(germBullet, transform.position, transform.rotation);
            Instantiate(germBullet, transform.position, Quaternion.Euler(0,0,45));
            Instantiate(germBullet, transform.position, Quaternion.Euler(0,0,-45));
            delay = 0;
        }
    }
    void Move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        
        
        Player play = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (gameObject.transform.position.y < -4.9)
        {
            Debug.Log("발동");
            play.fain += 7;
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
    public void Start()
    {
        var plr = GameObject.FindWithTag("Player").GetComponent<Player>();
        plr.iMoster += 1;
    }
}
