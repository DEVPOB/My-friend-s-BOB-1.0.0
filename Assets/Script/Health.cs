using System;
using System.Resources;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public GameObject Players;
    public float healthP = 100;
    public GameObject[] hearts;
    public bool dead;
    public GameObject impactEffect;
    public float inzonetimecount;
    public TextMeshProUGUI inzonetimeout;
    public Color newcolor;
    public float invisible;
    public WaveSetUp wave;
    public WaveSetUptwo wavetwo;
    [SerializeField]GameObject Bgmusic;
    
    
    void Inzonetimecount()
    {
        double dab;

        inzonetimecount -= Time.deltaTime;
        inzonetimeout.color = new Color(255f,140f,0);
        dab = Math.Round(inzonetimecount);
        inzonetimeout.text = "Exit in " + dab.ToString() + " Seconds";
        
            if (inzonetimecount < 0)
            {
                healthP = healthP - 34f;
                HealthSystem();
            }
    }
    void Update()
    {    
        //healthAdd when start new round
        HealthAddSystem();
        // OnDead
        if(dead == true)
        {
            // remove PlayerController() script
            // Destroy(Players.GetComponent<PlayerController>());
            // Destroy(gameObject);
            gameObject.SetActive(false);
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            SFXManager.sfxInstan.Audio.PlayOneShot(SFXManager.sfxInstan.Death);
            Bgmusic.SetActive(false);

            Invoke("wait",1f);
        }
        if (dead == false)
        {
            Bgmusic.SetActive(true);
        }
    }
    // function HealthSystem() for use
    void HealthSystem()
    {
        if(healthP <= 66.6666666666)
        {
            hearts[2].gameObject.SetActive(false);
            SFXManager.sfxInstan.Audio.PlayOneShot(SFXManager.sfxInstan.Damage);
            Instantiate(impactEffect, transform.position, Quaternion.identity);

        }
        
        // 
        if(healthP <= 33.3333333333)
        {
            hearts[1].gameObject.SetActive(false);
            SFXManager.sfxInstan.Audio.PlayOneShot(SFXManager.sfxInstan.Damage);

            Instantiate(impactEffect, transform.position, Quaternion.identity);

        }
        
        // 
        if(healthP <= 0)
        {
            hearts[0].gameObject.SetActive(false);
            SFXManager.sfxInstan.Audio.PlayOneShot(SFXManager.sfxInstan.Damage);

            Instantiate(impactEffect, transform.position, Quaternion.identity);

            dead = true;
            
        }
        
                
    }
    void HealthAddSystem()
    {
        if(healthP > 66.6666666668)
        {
            hearts[2].gameObject.SetActive(true);
        }
        if(healthP > 33.3333333335)
        {
            hearts[1].gameObject.SetActive(true);
        }
        if (healthP > 33.3333333335)
        {
            hearts[0].gameObject.SetActive(true);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "SimpleEnemy")
        {
            healthP = healthP - 34f;
            escapechance();
            StartCoroutine(returninvisible());
            HealthSystem();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "BulletFromShip")
        {
            healthP = healthP - 34f;
            escapechance();
            StartCoroutine(returninvisible());
            HealthSystem();
        }
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Water" || other.gameObject.tag == "DeadZone")
        {
            Inzonetimecount();

        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "WaterZone" || other.gameObject.name == "DeadZone")
        {
            inzonetimecount = 5;
            inzonetimeout.color = newcolor;
        }
       

    }


    /*function for use area*/


    /*This function use for check player if player stay inside longer than 5 seconds*/


    /*This function use when player get hit by enemy*/
    void escapechance()
    {
        invisible -= Time.deltaTime;
        if (invisible < 3)
        {
            Players.GetComponent<PlayerController>().speed *= 2f;
            
        }
    }
    /*This IEnumerator use when player return speed stat player*/
    IEnumerator returninvisible()
    {
        yield return new WaitForSeconds(2f);
        Players.GetComponent<PlayerController>().speed = 6f;
    }
    void wait()
    {
         wave.GetComponent<WaveSetUp>().Gameover();
            if (wave.enabled == false)
            {
                wavetwo.GetComponent<WaveSetUptwo>().Gameover();
            }
    }
}
