using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public void restartbutton()
    {
        SceneManager.LoadScene("Game");
    }
    public void exitbutton()
    {
        SceneManager.LoadScene("Menu");
    }
}
