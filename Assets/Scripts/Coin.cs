using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private GameObject score;
    private GameObject Coincount;

	// Use this for initialization
	void Start () {
        score = GameObject.FindGameObjectWithTag("Score");
        Coincount = GameObject.FindGameObjectWithTag("CoinCount");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        score.SendMessage("Coin");
        Destroy(gameObject);
        Coincount.SendMessage("Coin");
    }
}
