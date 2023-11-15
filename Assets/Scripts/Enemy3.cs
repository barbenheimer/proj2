using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public int hp = 4;

    public float fireRate;
    public GameObject bullet;
    public GameObject gun;

    private GameObject ObjectScoreScript;
    private Score scoreScript;

    public GameObject Explosion;
    public AudioClip pewpew;
    public AudioClip kaboom;
    public AudioClip ouchie;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gun = transform.Find("EnemyGun").gameObject;

        ObjectScoreScript = GameObject.Find("ScoreManager");
        scoreScript = ObjectScoreScript.GetComponent<Score>();

        speed = Random.Range(0.5f, 1f);
        fireRate = Random.Range(1.75f, 2.2f);
        InvokeRepeating("Shoot", fireRate, fireRate);
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void Shoot()
    {
        AudioSource.PlayClipAtPoint(pewpew, this.transform.position);
        Instantiate(bullet, gun.transform.position, Quaternion.identity);
        gun.GetComponent<Bullet>().ChangeDirection();
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
            scoreScript.AddScore(40);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(kaboom, this.transform.position);
        }
    }
}
