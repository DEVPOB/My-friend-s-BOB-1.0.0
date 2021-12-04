using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject Players;
    public float healthP = 100;
    public GameObject[] hearts;
    private bool dead;

    


    void Update()
    {
        // OnDead
        if(dead == true)
        {
            // remove PlayerController() script
            Destroy(Players.GetComponent<PlayerController>());
        }
    }
    // function HealthSystem() for use
    void HealthSystem()
    {
        if(healthP <= 66.6666666666)
        {
            Destroy(hearts[2].gameObject);
        }
        if(healthP <= 33.3333333333)
        {
            Destroy(hearts[1].gameObject);
        }
        if(healthP <= 0)
        {
            Destroy(hearts[0].gameObject);
        }
        
        
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Water":
            healthP = healthP - 33.3333333333f;
            HealthSystem();
            
            if(healthP <= 0)
            {
                dead = true;
            }
            break;
            case "SimpleEnemy":
            healthP = healthP - 100f;
            HealthSystem();
            if (healthP <= 0)
            {
                dead = true;
            }
            break;
        }
        
    }

}
