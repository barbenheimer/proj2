using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    Rigidbody2D rb;
    public int hp = 2;
    public float speed;

    private GameObject ObjectScoreScript;
    private Score scoreScript;

    public GameObject Explosion;
    public AudioClip kaboom;
    public AudioClip ouchie;
    void Start()
    {
        speed = Random.Range(2f, 4f);
        rb = GetComponent<Rigidbody2D>();
        ObjectScoreScript = GameObject.Find("ScoreManager");
        scoreScript = ObjectScoreScript.GetComponent<Score>();
    }

    
    void Update()
    {
        transform.Translate(Vector2.down*speed*Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag == "Player")
        {
            TakeDamage();
        }
    }
  
    public void TakeDamage()
    {
        AudioSource.PlayClipAtPoint(ouchie, this.transform.position);
        hp--;
        if (hp == 0)
        {
            Destroy(gameObject);
            scoreScript.AddScore(10);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(kaboom, this.transform.position);
        }
    }
}
