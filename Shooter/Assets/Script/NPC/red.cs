using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red : Enemy
{
    private void Update()
    {
        Move();
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
    void Move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        
        
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
        if (col.gameObject.tag != "Enemy")
        {
            var player = GameObject.FindWithTag("Player").GetComponent<Player>();
            player.fain += 10;
            Destroy(gameObject);
        }
            
    }   
}
