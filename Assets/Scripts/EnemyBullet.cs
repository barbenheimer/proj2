using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D rb;
    int dir = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 6);
    }

    public void ChangeDirection()
    {
        dir *= 1;
    }

    void Update()
    {
        rb.velocity = new Vector2(0, -3 * dir);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            c.gameObject.GetComponent<Player>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
