using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tolink : MonoBehaviour
{
    public void openurl(string url)
    {
        Application.OpenURL(url);
    }
}
