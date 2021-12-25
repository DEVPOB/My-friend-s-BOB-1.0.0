using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] GameObject pausemenu;

    // Start is called before the first frame update
  
    public void resume()
    {
                SFXManager.sfxInstan.Audio.PlayOneShot(SFXManager.sfxInstan.click);

        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<PlayerController>().enabled = true;

    }
    public void restartmenu()
    {
                SFXManager.sfxInstan.Audio.PlayOneShot(SFXManager.sfxInstan.click);

        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
    public void Mainmenu()
    {
                SFXManager.sfxInstan.Audio.PlayOneShot(SFXManager.sfxInstan.click);

        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;

    }
    public void exitmenu()
    {
                SFXManager.sfxInstan.Audio.PlayOneShot(SFXManager.sfxInstan.exitclick);

        Application.Quit();
    }

}
