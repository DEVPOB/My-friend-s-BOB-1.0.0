using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveSetUptwo : MonoBehaviour
{
    public GameObject wavesetup;
    public GameObject ShipEnemy;
    public GameObject simpleenemy;
    bool canspawn = true;
    int wavecountnum = 1;
    public GameObject gameoverscene;
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        
        spawnship();
        

    }

    public void Gameover()
    {
        gameoverscene.SetActive(true);
        score.text = "You Survived " + wavecountnum.ToString() + " Waves!";

    }
    // Update is called once per frame
    void Update()
    {
        
            wavesetup.GetComponent<WaveSetUp>().wavecountText.text = "wave: " + wavecountnum.ToString();
            GameObject[] totalenemy = GameObject.FindGameObjectsWithTag("SimpleEnemy");
            GameObject[] totalenemyship = GameObject.FindGameObjectsWithTag("ShipEnemy");
            if (canspawn == true)
            {
                if (totalenemy.Length == 0 &totalenemyship.Length == 0)
                {
                    Invoke("spawnship",0f);
                }
                if (wavecountnum == 3)
                {
                    print("test");
                }
            }
        
    }
    private void spawnship()
    {
        for (int i = 0; i < 2; i++)
        {
            Vector3 shipenemypos = new Vector3(Random.Range(50.26f,80.26f), Random.Range(90.26f, -20.68f), 0);
            Vector3 shipenemyposl = new Vector3(Random.Range(-40.26f,-45.85f), Random.Range(-10.68f, -20.68f), 0);

            Instantiate(ShipEnemy, shipenemypos, Quaternion.identity);
            Instantiate(ShipEnemy, shipenemyposl, Quaternion.identity);

        }
        for (int e = 0; e < 10; e++)
        {
            Vector3 simpleenemypos = new Vector3(Random.Range(-70, 70f), Random.Range(20f, 60f), 0);

            Instantiate(simpleenemy, simpleenemypos, Quaternion.identity);
        }
        wavecountnum += 1;
    }
}
