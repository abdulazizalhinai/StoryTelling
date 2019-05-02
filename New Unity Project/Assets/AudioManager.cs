using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    public AudioSource MusicSource2;
    public AudioClip MusicClip2;


    void Start()
    {
        MusicSource.clip = MusicClip;
        MusicSource2.clip = MusicClip2;

    }
    void Update()
    {
        //    if (Input.GetKeyDown(KeyCode.Space))

        //        MusicSource.Play();
        //}
    }
}
