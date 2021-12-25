using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraoffset;
    public float damping;
    public Health health;
    private Vector3  velocity = Vector3.zero;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        smoothlikebutter();

    }
    void smoothlikebutter()
    {

        if (health.healthP > 0)
        {
                
            Vector3 moveposition = target.position + cameraoffset;
            transform.position = Vector3.SmoothDamp(transform.position,moveposition,ref velocity,damping);
        }
    }
    
}
