using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CointCount : MonoBehaviour {

    private Text text;

    private int coin;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        if (PlayerPrefs.HasKey("Coin"))
        {
            
        }
        else
        {
            PlayerPrefs.SetInt("Coin", 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void Coin()
    {
        coin += 1;
        text.text = coin.ToString();
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
        
    }
    void respawn()
    {
        PlayerPrefs.Save();
        coin = 0;
        text.text = coin.ToString();
    }
}
