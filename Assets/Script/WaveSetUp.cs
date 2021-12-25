using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSetUp : MonoBehaviour
{
    public GameObject Players;
    public TextMeshProUGUI wavecountText; // use in line 24
    public  int wavecountnum = 0;
    public Transform Player;
    [SerializeField] private GameObject simpleenemy;
    bool halfwavecount = false;
    public bool nextwavenow = false;
    public WaveSetUptwo nextwave;
    public GameObject gameoverscene;
    public WaveSetUp Thiswave;
    public TextMeshProUGUI score;

    void Start()
    {
        Invoke("spawn",3f);
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        wavecountText.text = "wave: " + wavecountnum.ToString();  // wavecountnum use in line 54
        GameObject[] totalenemy = GameObject.FindGameObjectsWithTag("SimpleEnemy");
        if (halfwavecount == false)
        {
            if (totalenemy.Length == 3)
            {
                for (int i = 0; i < 1; i++)
                {
                    Invoke("spawn", 0f);
                    halfwavecount = true;
                }
                
            }
            if(halfwavecount == true)
            {
                Players.GetComponent<Health>().healthP += 34;
            }
        }
        if (halfwavecount == true)
        {
            if (totalenemy.Length == 0)
            {
                nextwave.enabled = true;
                Thiswave.enabled = false;
                // wait some hour time to relex
            }
        }
    }
    
    public void Gameover()
    {
        gameoverscene.SetActive(true);
        score.text = "You Survived " + wavecountnum.ToString() + " Waves!";

    }
   

    private void spawn()
    {
        for (int i = 0; i < 20; i++)
        {
            Vector3 simpleenemypos = new Vector3(Random.Range(-70, 70f), Random.Range(20f, 60f), 0);

            Instantiate(simpleenemy, simpleenemypos, Quaternion.identity);
        }
        wavecountnum = 1;
    }

    // IEnumerable Waitforsecond()
    // {

    // }
}
