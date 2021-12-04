using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float health = 100f;
    private bool dead;
    public float SESpeed = 3f;
    private Transform target;
    public GameObject impactEffect;
    void Update()
    {
        if(target != null)
        {
            float step = SESpeed * Time.deltaTime;
            rb.transform.position = Vector2.MoveTowards(transform.position,target.position,step);
        }
        if(dead == true)
        {
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, Quaternion.identity);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = other.transform;
            print("Lock target");
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "FirstBullet")
        {
            health = health - 20f;
            if(health <= 0)
            {
                dead = true;
                
            }
        }
    }
    // Use can use it if you want!
    
    // public void Impact()
    // {
    //     Instantiate(impactEffect, transform.position, Quaternion.identity);
    // }
    

}
