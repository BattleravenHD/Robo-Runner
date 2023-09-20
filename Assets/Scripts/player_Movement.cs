using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class player_Movement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public float FuelMax;
    public bool IsAlive = true;
    public Slider slide;
    public Text text;
    public GameObject panel;
    public List<AudioClip> aduio = new List<AudioClip>();
    public AudioSource play;
    public ParticleSystem fire;

    private float Fuel;
    private bool Moves;
    private bool Jumps;
    private Rigidbody2D ridged;
    private bool fuelrestock = true;
    private bool deathsetup = true;
    private Animator anim;
    private int deathbeforeadd;

    private int speedupgrade;
    private int thrustupgrade;
    private int fueltimeupgrade;
    private void Start()
    {
        deathbeforeadd = Random.Range(3, 6);
        ridged = GetComponent<Rigidbody2D>();
        
        slide.maxValue = FuelMax;
        slide.value = FuelMax;
        anim = GetComponent<Animator>();
        
        if (PlayerPrefs.HasKey("speedupgrade"))
        {
            speedupgrade = PlayerPrefs.GetInt("speedupgrade");
            print(speedupgrade);
        }
        else
        {
            PlayerPrefs.SetInt("speedupgrade", 0);
        }
        if (PlayerPrefs.HasKey("thrustupgrade"))
        {
            thrustupgrade = PlayerPrefs.GetInt("thrustupgrade");
            print(thrustupgrade);
        }
        else
        {
            PlayerPrefs.SetInt("thrustupgrade", 0);
        }
        if (PlayerPrefs.HasKey("fueltimeupgrade"))
        {
            fueltimeupgrade = PlayerPrefs.GetInt("fueltimeupgrade");
            print(fueltimeupgrade);
        }
        else
        {
            PlayerPrefs.SetInt("fueltimeupgrade", 0);
        }
        FuelMax += fueltimeupgrade * 20;
        Fuel = FuelMax;
        Speed += speedupgrade * 2.5f;
        JumpForce += thrustupgrade * 2.5f;
    }

    private void Update()
    {
        
        if (IsAlive == true)
        {
            if (ridged.velocity.x > 0 && play.isPlaying != true && ridged.velocity.y < 0.01f && ridged.velocity.y < -0.01f)
            {
                play.clip = aduio[0];
                play.Play();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Move();
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Jump();
            }
            if (Fuel <= 5 && fuelrestock == true)
            {
                fuelrestock = false;
                StartCoroutine(Restoke());
            }
            if (Moves == true)
            {
                ridged.AddForce(new Vector2((Speed - ridged.velocity.x), 0));
                anim.SetBool("Running", true);

            }
            else if (Moves == false)
            {
                ridged.AddForce(new Vector2(-ridged.velocity.x * 20, 0));
                anim.SetBool("Running", false);
            }
            if (Jumps == true)
            {
                if (fuelrestock == true)
                {
                    ridged.AddForce(new Vector2(0, Mathf.Clamp(JumpForce - ridged.velocity.y, 0, JumpForce)));
                    Fuel -= 2;
                    slide.value -= 2;
                    fire.Play();
                    if (play.clip != aduio[1])
                    {
                        play.Stop();
                        play.clip = aduio[1];
                        play.Play();
                        
                    }else if (play.isPlaying == false)
                    {
                        play.clip = aduio[1];
                        play.Play();
                    }
                }else
                {
                    if (play.clip == aduio[1])
                    {
                        play.Stop();
                    }
                }
            }else
            {
                fire.Stop();
                if (play.clip == aduio[1])
                {
                    play.Stop();
                }
                
            }
            if (Fuel < FuelMax && Jumps == false && fuelrestock == true)
            {
                Fuel += 1;
                slide.value += 1;
            }
            Moves = false;
            Jumps = false;
        }else 
        {
            if (deathsetup == true)
            {
                play.Stop();
                panel.SetActive(true);
                Text obj = Instantiate(text, panel.transform);
                obj.fontSize = 80;
                Text obj2 = Instantiate(text, panel.transform);
                obj2.name = "High Score (Clone)";
                obj2.gameObject.SendMessage("endscores");
                obj.gameObject.SendMessage("endscore");
                obj2.fontSize = 80;
                obj.rectTransform.Translate(new Vector3(0,-130,0));
                obj2.rectTransform.Translate(new Vector3(0, -75, 0));
                deathsetup = false;
                text.gameObject.SetActive(false);
                deathbeforeadd -= 1;
                if (deathbeforeadd == 0)
                {
                    //Advertisement.Show();
                    deathbeforeadd = Random.Range(2, 5);
                }
            }
        }
    }
    void Move()
    {
        Moves = true;
    }
    void Jump()
    {
        Jumps = true;
    }
    IEnumerator Restoke()
    {
        ridged.AddForce(new Vector2( 0,-ridged.velocity.y/2));
        yield return new WaitForSeconds(2.25f);
        Fuel = FuelMax/2;
        fuelrestock = true;
        slide.value = FuelMax / 2;
    }
    void Die()
    {
        IsAlive = false;
    }
    void Live()
    {
        IsAlive = true;
        ridged.simulated = true;
        deathsetup = true;
    }


}
