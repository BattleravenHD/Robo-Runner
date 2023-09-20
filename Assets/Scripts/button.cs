using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour {

    public bool Is_Respawn;
    public GameObject player;
    public GameObject levelspawner;
    public GameObject panel;
    public GameObject score;
    public GameObject lava;
    public GameObject coin;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    void Trigger()
    {
        if (Is_Respawn == true)
        {
            player.transform.position = new Vector3(0,2);
            levelspawner.GetComponent<Level_Gen>().Generatenew();   
            lava.SendMessage("Restart");
            score.SetActive(true);
            score.SendMessage("respawn");
            panel.BroadcastMessage("respawn");
            panel.SetActive(false);
            player.SendMessage("Live");
            coin.SendMessage("respawn");
            
        }
        else
        {
            SceneManager.LoadScene("Stats_and_Upgrades");
        }  
    }
}
