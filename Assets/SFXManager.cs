using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip Death;
    public AudioClip Damage;
    public AudioClip ShotEzOneTap;
    public AudioClip EzHitBozo;
    public AudioClip click;
    public AudioClip exitclick;
    public static SFXManager sfxInstan;
    // Start is called before the first frame update
    private void Awake()
    {
        if (sfxInstan != null && sfxInstan != this)
        {
            Destroy(this.gameObject);
            return;
        }
        sfxInstan = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
