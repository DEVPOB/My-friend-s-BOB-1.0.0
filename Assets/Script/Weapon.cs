using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject bullet;
    public Transform firepoint;
    public float fireForce;
    public void Fire()
    {
        GameObject projectile = Instantiate(bullet,firepoint.position,firepoint.rotation);
        SFXManager.sfxInstan.Audio.PlayOneShot(SFXManager.sfxInstan.ShotEzOneTap);
        projectile.GetComponent<Rigidbody2D>().AddForce(firepoint.up * fireForce,ForceMode2D.Impulse);
            
            
    }
    

}
