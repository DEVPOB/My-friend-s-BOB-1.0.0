using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFromShip : MonoBehaviour
{
    Health Players;
    Bullet bullet;
    public GameObject impactEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroy",5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }
    }
    void destroy()
    {
        Destroy(gameObject);
    }
}
