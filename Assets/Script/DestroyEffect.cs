using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy",6f);
    }

    // Update is called once per frame
    void Destroy()
    {
        Destroy(effect);
    }
}
