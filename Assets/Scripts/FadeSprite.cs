using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSprite : MonoBehaviour {
    public Color startColor;
    public Color endColor;

    public float fadeInTime = 1f;
    public float fadeOutTime = 2f;
    public float fadeDelay = 3f;

    public SpriteRenderer _spriteRender;

    void Awake()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
    }
    void Start (){
        StartCoroutine(ColorLerpIn());
    }
    IEnumerator colorLerpIn()
    {
        for(float t=0.01f; t<fadeInTime; t += 0.1f) {
            _spriteRender.material.color = Color.Lerp (startColor,endColor, t/fadeInTime);
            yield return null;
        }
        StartCoroutine(ColorLerpOut());
    }

    private string ColorLerpOut()
    {
        throw new NotImplementedException();
    }

    IEnumerator ColorLerpIn()
    {
        for (float t = 0.01f; t < fadeOutTime; t += 0.1f)
        {
            _spriteRender.material.color = Color.Lerp(endColor,startColor, t / fadeOutTime);
            yield return null;
        }


    }
}
