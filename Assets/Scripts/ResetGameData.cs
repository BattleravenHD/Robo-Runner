using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ResetGameData : MonoBehaviour {

    public AudioMixer mix;
    public Slider main;
    public Slider music;
    public Slider effects;

    // Use this for initialization
    void Start () {
        float m = 0;
        mix.GetFloat("MasterVolume", out m);
        main.value = m;
        mix.GetFloat("MusicVolume", out m);
        music.value = m;
        mix.GetFloat("EffectVolume", out m);
        effects.value = m;
    }
	
	// Update is called once per frame
	void Update () {

	}
    void resetgamedata()
    {
        if (PlayerPrefs.HasKey("High Score"))
        {
            PlayerPrefs.SetInt("High Score", 0);
        }
        else
        {
            PlayerPrefs.SetInt("High Score", 0);
        }
        if (PlayerPrefs.HasKey("Coin"))
        {
            PlayerPrefs.SetInt("Coin", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Coin", 0);
        }
        if (PlayerPrefs.HasKey("speedupgrade"))
        {
            PlayerPrefs.SetInt("speedupgrade", 0);
        }
        else
        {
            PlayerPrefs.SetInt("speedupgrade", 0);
        }
        if (PlayerPrefs.HasKey("thrustupgrade"))
        {
            PlayerPrefs.SetInt("thrustupgrade", 0);
        }
        else
        {
            PlayerPrefs.SetInt("thrustupgrade", 0);
        }
        if (PlayerPrefs.HasKey("fueltimeupgrade"))
        {
            PlayerPrefs.SetInt("fueltimeupgrade", 0);
        }
        else
        {
            PlayerPrefs.SetInt("fueltimeupgrade", 0);
        }
    }
    public void SetSounde(float soundLevel)
    {
        mix.SetFloat("EffectVolume", soundLevel);
    }
    public void SetSoundm(float soundLevel)
    {
        mix.SetFloat("MasterVolume", soundLevel);
    }
    public void SetSoundmu(float soundLevel)
    {
        mix.SetFloat("MusicVolume", soundLevel);
    }
}

