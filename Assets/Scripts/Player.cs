using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gun;
    Rigidbody2D rb;

    public float xSpeed = 1.5f;
    public float ySpeed = 1f;

    public int maxHp = 10;
    public int currentHp;
    public bool invin = false;

    public GameObject Explosion;

    public AudioClip pewpew;
    public AudioClip kaboom;
    public AudioClip ouchie;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gun = transform.Find("Gun").gameObject;
        currentHp = maxHp;
    }

    void Update()
    {
        //movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //Vector2 direction = new Vector2(horizontal*xSpeed, vertical*ySpeed);
        rb.AddForce(new Vector2(horizontal * xSpeed, 0));
        rb.AddForce(new Vector2(0, vertical * ySpeed));

        //shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, gun.transform.position,Quaternion.identity);
            AudioSource.PlayClipAtPoint(pewpew, this.transform.position);
        }
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag == "Enemy" && invin == false)
        {
           TakeDamage();
        }
        else if (c.collider.tag == "Enemy2" && invin == false)
        {
           TakeDamage();
        }
        else if (c.collider.tag == "Enemy3" && invin == false)
        {
           TakeDamage();
        }
    }
    public void TakeDamage()
    {
        AudioSource.PlayClipAtPoint(ouchie, this.transform.position);
        currentHp --;
        StartCoroutine("IFrames");
        if(currentHp == 0)
        {
            Destroy(gameObject);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(kaboom, this.transform.position);
            SceneManager.LoadScene("GameOver");
        }
    }

    IEnumerator IFrames()
    {
        invin = true;
        for(int i = 0; i < 3; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
            yield return new WaitForSeconds(0.08f);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            yield return new WaitForSeconds(0.08f);
        }
        invin = false;
    }
}
