using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    int dir = 1; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
    }
    public void ChangeDirection()
    {
        dir *= -1;
    }

    void Update()
    {
        rb.velocity= new Vector2(0,12*dir);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            c.gameObject.GetComponent<Enemy>().TakeDamage();
            Destroy(gameObject);
        }
        else if (c.gameObject.tag == "Enemy2")
        {
            c.gameObject.GetComponent<Enemy2>().TakeDamage();
            Destroy(gameObject);
        }
        else if (c.gameObject.tag == "Enemy3")
        {
            c.gameObject.GetComponent<Enemy3>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
