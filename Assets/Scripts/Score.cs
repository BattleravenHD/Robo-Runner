using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Score : MonoBehaviour {

    private bool isalive = true;
    private Text scoretext;
    public float score;
    private float highscore;

	// Use this for initialization
	void Start () {
        scoretext = GetComponent<Text>();
        StartCoroutine(Timescore());
        if (PlayerPrefs.HasKey("High Score"))
        {
            highscore = PlayerPrefs.GetInt("High Score");
        }else
        {
            PlayerPrefs.SetInt("High Score", 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator Timescore()
    {
        yield return new WaitForSeconds(1);
        
        if (isalive == true)
        {
            score += 1;
            scoretext.text = score.ToString();
            StartCoroutine(Timescore());
        }
    }
    void Die()
    {
        isalive = false;
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("High Score", (int)highscore);
            PlayerPrefs.Save();
            scoretext.text = "High Score: " + PlayerPrefs.GetInt("High Score").ToString();
        }
        if (name.Contains("High Score"))
        {
            scoretext.text = "High Score: " + PlayerPrefs.GetInt("High Score").ToString();
        }  
    }
    void Coin()
    {
        score += 10;
        scoretext.text = score.ToString();
    }
    void endscore()
    {
        isalive = false;
        StopAllCoroutines();
        scoretext = GetComponent<Text>();
        scoretext.text = "Score: " + score.ToString();
    }
    void endscores()
    {
        scoretext = GetComponent<Text>();
        isalive = false;
        StopAllCoroutines();
        scoretext.text = "High Score: " + PlayerPrefs.GetInt("High Score").ToString();
    }
    void respawn()
    {
        isalive = true;
        score = 0;
        StartCoroutine(Timescore());
        scoretext.text = score.ToString();
        if (gameObject.name.Contains("(Clone)"))
        {
            Destroy(gameObject);
        }
    }
}
