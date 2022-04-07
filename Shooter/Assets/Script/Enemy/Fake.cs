using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fake : Enemy
{
    public GameObject bullet;
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
            Instantiate(bullet, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

}
