using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerper : MonoBehaviour
{

    public float speed = 0.1f;
    public Color startColor;
    public Color endColor;
    public bool repeatable = false,music=false;
    float startTime;
    float timer = 0;
    float t;
    public Color color;
    public AudioClip Done;
    
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("color", 0);
        startTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (!repeatable)
        {
            if (color == endColor)
            {
                repeatable = true;
                PlayerPrefs.SetInt("color", PlayerPrefs.GetInt("color") + 1);
                print(PlayerPrefs.GetInt("color"));
            }
        }
            GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
       color= GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
        if(PlayerPrefs.GetInt("color")==7)
        {
            if (!music)
            {
                music = true;
                SoundManager.instance.PlaySingle(Done);
            }
        }

    }
    private void OnMouseDown()
    {
        timer += 0.5f;
        t = (timer - startTime) * speed;
       
    }


}

