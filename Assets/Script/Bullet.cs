using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject impactEffect;
    
    void Start()
    {
        Invoke("OnDestroy",6f);
        
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "SimpleEnemy":
            Destroy(gameObject); // Destroy Bullet
            break;
            case "ShipEnemy":
            Destroy(gameObject);
            break;
         }
    }
    public void Impact()
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void OnDestroy()
    {
        Destroy(gameObject);
    }
}
