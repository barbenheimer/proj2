using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public int hp = 2;
    public Transform player;
    private Vector2 movement;

    private GameObject ObjectScoreScript;
    private Score scoreScript;

    public GameObject Explosion;
    public AudioClip kaboom;
    //public AudioClip ouchie;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        ObjectScoreScript = GameObject.Find("ScoreManager");
        scoreScript = ObjectScoreScript.GetComponent<Score>();
    }
    void Update()
    {
        if (player != null)
        {
            Vector2 dir = player.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            dir.Normalize();
            movement = dir;
        }
        
    }

    void moveEnemy(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir*speed*Time.deltaTime));
    }

    void FixedUpdate()
    {
        moveEnemy(movement);
    }

        void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag == "Player" )
        {
            TakeDamage();
        }
    }
    
    public void TakeDamage()
    {
        //AudioSource.PlayClipAtPoint(ouchie, this.transform.position);
        hp--;
        if (hp == 0)
        {
            Destroy(gameObject);
            scoreScript.AddScore(20);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(kaboom, this.transform.position);
        }
    }
}
