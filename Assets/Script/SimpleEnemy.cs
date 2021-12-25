using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float health = 100f;
    Health healths;
    private bool dead;
    public float SESpeed = 3f;
    private Transform target;
    public GameObject impactEffect;
    private Vector2 OG;
    public Vector2 direction;
    void Start()
    {
        healths = GameObject.FindWithTag("Player").GetComponent<Health>();
        

    }

    void Update()
    {
        // See Player
        if(target != null)
        {
            float step = SESpeed * Time.deltaTime;
            rb.transform.position = Vector2.MoveTowards(transform.position,target.position,step);
        }
        if (healths.GetComponent<Health>().healthP <= 0)
        {
            SESpeed = 0;
        }
        // Dead Event
        if(dead == true)
        {
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }
        
        
    }
    
    // Find Player
    void OnTriggerStay2D(Collider2D other)
    {
        
        if(other.gameObject.name == "Player")
        {
            target = other.transform;
        }
        
        
    }
    // Check Bullet
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "FirstBullet")
        {
            health = health - 25f;
            SFXManager.sfxInstan.Audio.PlayOneShot(SFXManager.sfxInstan.EzHitBozo);

            StartCoroutine(hiteffect()); 
            if(health <= 0)
            {
                dead = true;
                SFXManager.sfxInstan.Audio.PlayOneShot(SFXManager.sfxInstan.Death);
            }
        }
       
    }
    IEnumerator hiteffect()
    {
        GetComponent<SpriteRenderer> ().color = Color.white;
        yield return new WaitForSeconds(0.01f);
        GetComponent<SpriteRenderer> ().color = Color.red;
    }

}
