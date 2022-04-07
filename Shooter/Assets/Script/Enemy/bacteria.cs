using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class bacteria : Enemy
{

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    void Move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        
        Player play = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (gameObject.transform.position.y < -4.9)
        {
            Debug.Log("발동");
            play.fain += 6;
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
