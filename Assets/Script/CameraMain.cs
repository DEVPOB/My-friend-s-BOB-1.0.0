using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraoffset;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        transform.position = target.position + cameraoffset;
    }
}
