using System.Security.Cryptography;
using System;

using UnityEngine;
using Random = UnityEngine.Random;

public class turrentscript : MonoBehaviour
{
    // public Transform firepoint;
    bool Detect = false;
    Vector2 Direction;
    public GameObject gun;
    private GameObject something;
    public GameObject Bullet;
    public float health = 100;
    float nexttimetofire = 0;
    public Transform shootpoint;
    public float fireforce;
    private bool dead = false;
    public Rigidbody2D rb;
    private bool rotate = false;
    public GameObject impactEffect;



    void Awake()
    {
        something = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector2 targetpos = something.transform.position;


        Direction = targetpos - (Vector2)transform.position;
        RaycastHit2D rayinfo = Physics2D.Raycast(transform.position, Direction);
        if (dead == true)
        {
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, Quaternion.identity);

        }

    }
    void FixedUpdate()
    {
        if (rotate == true)
        {
            transform.position = new Vector2(transform.position.x + .05f, -20.68f); // move right
            if (transform.position.x > 39.82f)
            {
                rotate = false;
            }
        }
        if (rotate == false)
        {
            transform.position = new Vector2(transform.position.x - .05f, -20.68f); // move left
            if (transform.position.x < -30.52f)
            {
                rotate = true;
            }

        }
    }
    void OnTriggerStay2D(Collider2D other)
    {

        if (something.transform != null)
        {
            if (Detect == false)
            {
                Detect = true;
            }
            if (Detect)
            {
                gun.transform.up = Direction;
                if (Time.time > nexttimetofire)
                {
                    nexttimetofire = Time.time + 1 / 1;
                    Shoot();
                }
            }
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FirstBullet")
        {
            health = health -= 50;
            SFXManager.sfxInstan.Audio.PlayOneShot(SFXManager.sfxInstan.EzHitBozo);

            if (health <= 0)
            {
                dead = true;
                SFXManager.sfxInstan.Audio.PlayOneShot(SFXManager.sfxInstan.Death);

            }
        }

    }

    void Shoot()
    {
        GameObject bulletins = Instantiate(Bullet, shootpoint.position, Quaternion.identity);
        SFXManager.sfxInstan.Audio.PlayOneShot(SFXManager.sfxInstan.EzHitBozo);

        bulletins.GetComponent<Rigidbody2D>().AddForce(shootpoint.transform.up * fireforce);
    }



}
