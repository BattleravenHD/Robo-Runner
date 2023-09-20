using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Upgrade : MonoBehaviour {

    public Image im;
    public List<Sprite> image = new List<Sprite>();
    public Text upgrade;

    private int coincount;
    private int speedupgrade;
    private int thrustupgrade;
    private int fueltimeupgrade;
    private int upgradenum = 0;
    private int scroll;
    private bool unlock;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("Coin"))
        {
            coincount = PlayerPrefs.GetInt("Coin");
        }
        else
        {
            PlayerPrefs.SetInt("Coin", 0);
        }
        if (PlayerPrefs.HasKey("speedupgrade"))
        {
            speedupgrade = PlayerPrefs.GetInt("speedupgrade");
        }
        else
        {
            PlayerPrefs.SetInt("speedupgrade", 0);
        }
        if (PlayerPrefs.HasKey("thrustupgrade"))
        {
            thrustupgrade = PlayerPrefs.GetInt("thrustupgrade");
        }
        else
        {
            PlayerPrefs.SetInt("thrustupgrade", 0);
        }
        if (PlayerPrefs.HasKey("fueltimeupgrade"))
        {
            fueltimeupgrade = PlayerPrefs.GetInt("fueltimeupgrade");
        }
        else
        {
            PlayerPrefs.SetInt("fueltimeupgrade", 0);
        }
        GetComponent<Text>().text = coincount.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        im.sprite = image[scroll + upgradenum];
        if (scroll + upgradenum == 0)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(70, 197);
            rt.transform.position = new Vector3(355 * (Screen.height / 330), 165 * (Screen.height / 330), 0);

            im.color = Color.white;
            upgrade.text = "Play";
            unlock = false;
            
        }
        if (scroll + upgradenum == 1)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(70 , 197 );
            rt.transform.position = new Vector3(355 * (Screen.height / 330), 165 * (Screen.height / 330), 0);
            if (thrustupgrade >= 1)
            {
                im.color = Color.white;
                upgrade.text = "Play";
                unlock = false;
            }
            else
            {
                im.color = Color.black;
                upgrade.text = "Unlock: Cost 20";
                unlock = true;
            }
        }
        if (scroll + upgradenum == 2)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(96, 270);
            rt.transform.position = new Vector3(350 * (Screen.height / 330), 145 * (Screen.height / 330));
            if (thrustupgrade >= 2)
            {
                im.color = Color.white;
                upgrade.text = "Play";
                unlock = false;
            }
            else if (thrustupgrade == 1)
            { 
                im.color = Color.black;
                upgrade.text = "Unlock: Cost 40";
                unlock = true;
            }
            else
            {
                print(thrustupgrade);
                im.color = Color.black;
                upgrade.text = "Locked";
                unlock = false;
            }
            
        }
        if (scroll + upgradenum == 3)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(96, 270);
            rt.transform.position = new Vector3(350 * (Screen.height / 330), 145 * (Screen.height / 330));
            if (thrustupgrade >= 3)
            {
                im.color = Color.white;
                upgrade.text = "Play";
                unlock = false;
            }
            else if (thrustupgrade == 2)
            {
                im.color = Color.black;
                upgrade.text = "Unlock: Cost 60";
                unlock = true;
            }
            else
            {
                im.color = Color.black;
                upgrade.text = "Locked";
                unlock = false;
            }
        }
        if ( scroll + upgradenum == 4)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(150, 215);
            rt.transform.position = new Vector3(365 * (Screen.height / 330), 165 * (Screen.height / 330));
            if (thrustupgrade == 5)
            {
                im.color = Color.white;
                upgrade.text = "Play";
                unlock = false;
            }
            else if (thrustupgrade == 4)
            {
                im.color = Color.black;
                upgrade.text = "Unlock: Cost 100";
                unlock = true;
            }
            else
            {
                im.color = Color.black;
                upgrade.text = "Locked";
                unlock = false;
            }
        }

        if (scroll + upgradenum == 5 )
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(150, 215);
            rt.transform.position = new Vector3(365 * (Screen.height / 330), 165 * (Screen.height / 330));
            
            if (thrustupgrade >= 4)
            {
                im.color = Color.white;
                upgrade.text = "Play";
                unlock = false;
            }
            else if (thrustupgrade == 3)
            {
                im.color = Color.black;
                upgrade.text = "Unlock: Cost 80";
                unlock = true;
            }
            else
            {
                im.color = Color.black;
                upgrade.text = "Locked";
                unlock = false;
            }
        }
        if (scroll + upgradenum == 6)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(70, 197);
            rt.transform.position = new Vector3(355 * (Screen.height / 330), 165 * (Screen.height / 330), 0);

            im.color = Color.white;
            upgrade.text = "Play";
            unlock = false;

        }
        if (scroll + upgradenum == 7)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(179, 113);
            rt.transform.position = new Vector3(355 * (Screen.height / 330), 165 * (Screen.height / 330), 0);
            if (speedupgrade >= 1)
            {
                im.color = Color.white;
                upgrade.text = "Play";
                unlock = false;
            }
            else
            {
                im.color = Color.black;
                upgrade.text = "Unlock: Cost 15";
                unlock = true;
            }
        }
        if (scroll + upgradenum == 8)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(179, 113);
            rt.transform.position = new Vector3(350 * (Screen.height / 330), 145 * (Screen.height / 330));
            if (speedupgrade >= 2)
            {
                im.color = Color.white;
                upgrade.text = "Play";
                unlock = false;
            }
            else if (speedupgrade == 1)
            {
                im.color = Color.black;
                upgrade.text = "Unlock: Cost 30";
                unlock = true;
            }
            else
            {
                print(thrustupgrade);
                im.color = Color.black;
                upgrade.text = "Locked";
                unlock = false;
            }

        }
        if (scroll + upgradenum == 9)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(179, 150);
            rt.transform.position = new Vector3(350 * (Screen.height / 330), 145 * (Screen.height / 330));
            if (speedupgrade >= 3)
            {
                im.color = Color.white;
                upgrade.text = "Play";
                unlock = false;
            }
            else if (speedupgrade == 2)
            {
                im.color = Color.black;
                upgrade.text = "Unlock: Cost 45";
                unlock = true;
            }
            else
            {
                im.color = Color.black;
                upgrade.text = "Locked";
                unlock = false;
            }
        }
        if (scroll + upgradenum == 10)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(221, 125);
            rt.transform.position = new Vector3(365 * (Screen.height / 330), 165 * (Screen.height / 330));
            if (speedupgrade == 5)
            {
                im.color = Color.white;
                upgrade.text = "Play";
                unlock = false;
            }
            else if (speedupgrade == 4)
            {
                im.color = Color.black;
                upgrade.text = "Unlock: Cost 60";
                unlock = true;
            }
            else
            {
                im.color = Color.black;
                upgrade.text = "Locked";
                unlock = false;
            }
        }

        if (scroll + upgradenum == 11)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(221, 125);
            rt.transform.position = new Vector3(365 * (Screen.height / 330), 165 * (Screen.height / 330));

            if (speedupgrade >= 4)
            {
                im.color = Color.white;
                upgrade.text = "Play";
                unlock = false;
            }
            else if (speedupgrade == 3)
            {
                im.color = Color.black;
                upgrade.text = "Unlock: Cost 80";
                unlock = true;
            }
            else
            {
                im.color = Color.black;
                upgrade.text = "Locked";
                unlock = false;
            }

        }
        if (scroll + upgradenum == 12)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(70, 197);
            rt.transform.position = new Vector3(355 * (Screen.height / 330), 165 * (Screen.height / 330), 0);

            im.color = Color.white;
            upgrade.text = "Play";
            unlock = false;

        }
        if (scroll + upgradenum == 13)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(179, 113);
            rt.transform.position = new Vector3(355 * (Screen.height / 330), 165 * (Screen.height / 330), 0);
            if (fueltimeupgrade >= 1)
            {
                im.color = Color.white;
                upgrade.text = "Play";
                unlock = false;
            }
            else
            {
                im.color = Color.black;
                upgrade.text = "Unlock: Cost 10";
                unlock = true;
            }
        }
        if (scroll + upgradenum == 14)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(179, 113);
            rt.transform.position = new Vector3(350 * (Screen.height / 330), 145 * (Screen.height / 330));
            if (fueltimeupgrade >= 2)
            {
                im.color = Color.white;
                upgrade.text = "Play";
                unlock = false;
            }
            else if (fueltimeupgrade == 1)
            {
                im.color = Color.black;
                upgrade.text = "Unlock: Cost 20";
                unlock = true;
            }
            else
            {
                print(thrustupgrade);
                im.color = Color.black;
                upgrade.text = "Locked";
                unlock = false;
            }

        }
        if (scroll + upgradenum == 15)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(179, 150);
            rt.transform.position = new Vector3(350 * (Screen.height / 330), 145 * (Screen.height / 330));
            if (fueltimeupgrade >= 3)
            {
                im.color = Color.white;
                upgrade.text = "Play";
                unlock = false;
            }
            else if (fueltimeupgrade == 2)
            {
                im.color = Color.black;
                upgrade.text = "Unlock: Cost 30";
                unlock = true;
            }
            else
            {
                im.color = Color.black;
                upgrade.text = "Locked";
                unlock = false;
            }
        }
        if (scroll + upgradenum == 16)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(221, 125);
            rt.transform.position = new Vector3(365 * (Screen.height / 330), 165 * (Screen.height / 330));
            if (fueltimeupgrade == 5)
            {
                im.color = Color.white;
                upgrade.text = "Play";
                unlock = false;
            }
            else if (fueltimeupgrade == 4)
            {
                im.color = Color.black;
                upgrade.text = "Unlock: Cost 40";
                unlock = true;
            }
            else
            {
                im.color = Color.black;
                upgrade.text = "Locked";
                unlock = false;
            }
        }

        if (scroll + upgradenum == 11)
        {
            RectTransform rt = im.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(221, 125);
            rt.transform.position = new Vector3(365 * (Screen.height / 330), 165 * (Screen.height / 330));

            if (speedupgrade >= 4)
            {
                im.color = Color.white;
                upgrade.text = "Play";
                unlock = false;
            }
            else if (speedupgrade == 3)
            {
                im.color = Color.black;
                upgrade.text = "Unlock: Cost 50";
                unlock = true;
            }
            else
            {
                im.color = Color.black;
                upgrade.text = "Locked";
                unlock = false;
            }

        }
    }
    void up()
    {
        if (scroll == 0 || scroll == thrustupgrade || scroll == speedupgrade || scroll == fueltimeupgrade)
        {
            SceneManager.LoadScene("Main_Parkour");
        }
        if (upgradenum == 0)
        {
            if (Mathf.Clamp(scroll - 1, 1, 6) == thrustupgrade && coincount > (20 * thrustupgrade + 20))
            {
                thrustupgrade += 1;
                PlayerPrefs.SetInt("thrustupgrade", thrustupgrade);
                PlayerPrefs.Save();
                coincount -= (20 * thrustupgrade + 20);
                GetComponent<Text>().text = coincount.ToString();
            }
        }
        if (upgradenum == 5)
        {
            if (Mathf.Clamp(scroll - 1, 1, 6) == speedupgrade && coincount > (15 * thrustupgrade + 15))
            {
                speedupgrade += 1;
                PlayerPrefs.SetInt("speedupgrade", speedupgrade);
                PlayerPrefs.Save();
                coincount -= (15 * speedupgrade + 15);
                GetComponent<Text>().text = coincount.ToString();
            }
        }
        if (upgradenum == 10)
        {
            if (Mathf.Clamp(scroll - 1, 1, 6) == fueltimeupgrade && coincount > (10 * fueltimeupgrade + 10))
            {
                fueltimeupgrade += 1;
                PlayerPrefs.SetInt("fueltimeupgrade", fueltimeupgrade);
                PlayerPrefs.Save();
                coincount -= (10 * fueltimeupgrade + 10);
                GetComponent<Text>().text = coincount.ToString();
            }
        }
    }
    void supgrade()
    {
        upgradenum = 6;
        scroll = 0;
    }
    void tupgrade()
    {
        upgradenum = 0;
        scroll = 0;
    }
    void fupgrade()
    {
        upgradenum = 12;
        scroll = 0;
    }
    void left()
    {
        scroll = Mathf.Clamp(scroll - 1, 0, 4);
    }
    void right()
    {
        scroll = Mathf.Clamp(scroll + 1, 0, 4);
    }
}
