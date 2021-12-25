using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI loadingtext;

    [SerializeField] GameObject loadingscene;   
    public void startmenu(int sceneIndex)
    {
        SFXManager.sfxInstan.Audio.PlayOneShot(SFXManager.sfxInstan.click);

        StartCoroutine(LoadAsync(sceneIndex));

    }
    
    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingscene.SetActive(true);
        
        yield return null;
    }
   
    public void exitmenu()
    {
        SFXManager.sfxInstan.Audio.PlayOneShot(SFXManager.sfxInstan.exitclick);

        Application.Quit();
    }
}
