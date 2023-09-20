using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

    public GameObject text;

    private bool rise = true;
    private GameObject player;
    private float risespeed;
    private float playerx;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(speedup());
        risespeed = 0.01f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.WorldToScreenPoint(transform.position).y > 0)
        {
            StopAllCoroutines();
            rise = false;
            risespeed = 0.01f;
        }
        if (rise == true)
        {
            transform.Translate(new Vector3(0, risespeed, 0));
            transform.transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            transform.GetComponent<SpriteRenderer>().size = new Vector2(transform.GetComponent<SpriteRenderer>().size.x + (player.transform.position.x - playerx), 8);
            playerx = player.transform.position.x;
        } 
	}
    IEnumerator speedup()
    {
        yield return new WaitForSeconds(10);
        risespeed = Mathf.Clamp(risespeed += 0.0025f, 0.005f, 0.025f);
        StartCoroutine(speedup());
        Debug.Log(risespeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.SendMessage("Die");
            text.SendMessage("Die");
            collision.transform.GetComponent<Rigidbody2D>().simulated = false;
            StopAllCoroutines();
        }
    }
    private void Restart()
    {
        transform.Translate(new Vector3(0, risespeed * 10, 0));
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        transform.position = new Vector2(player.transform.position.x, -12f);
        risespeed = 0.01f;
        rise = true;
        StartCoroutine(speedup());
    }
}
