using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class White : Enemy
{

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    public GameObject Item6;

    public int selectItem;


    private void Update()
    {
        Move();
    }
    
    void Move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        
        if (transform.position.x <= -2.9)
        {
            gameObject.transform.position = new Vector3(-2.9f,transform.position.y, transform.position.z );
        }
        
        if (transform.position.x >= 2.9)
        {
            gameObject.transform.position = new Vector3(2.9f, transform.position.y, transform.position.z);
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
            selectItem = Random.Range(1, 7);

            switch (selectItem)
            {
                case 1:
                    Instantiate(Item1, transform.position, transform.rotation);
                    break;
                case 2:
                    Instantiate(Item2, transform.position, transform.rotation);
                    break;
                case 3:
                    Instantiate(Item3, transform.position, transform.rotation);
                    break;
                case 4:
                    Instantiate(Item4, transform.position, transform.rotation);
                    break;
                case 5:
                    Instantiate(Item5, transform.position, transform.rotation);
                    break;
                case 6:
                    Instantiate(Item6, transform.position, transform.rotation);
                    break;
            }
            
            Destroy(gameObject);
        }
    }
 
}

