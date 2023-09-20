using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourLerp : MonoBehaviour {
    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private Color startColour;
    [SerializeField]
    private Color endColour;

    float startTime;
    
	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float t = (Time.time - startTime) * speed;
        GetComponent<Renderer>().material.color = Color.Lerp(startColour, endColour, t);
	}
}
