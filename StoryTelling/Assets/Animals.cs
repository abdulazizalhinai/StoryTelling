using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour
{
    public AudioSource MyAudio;
    public AudioSource SFXSource;

    public AudioClip[] Animal;

    public AudioClip Wright;
    public AudioClip Wrong;

    public GameObject BOX1;
    public GameObject BOX2;
    public GameObject BOX3;
    public GameObject CARANT1;


    int CurrentIndex;

    public static Animals Instance;
    // Start is called before the first frame update
    void Start()
    {
        sound();

        Instance = this;
    }

    // Update is called once per frame

    public void sound()
    {

        CurrentIndex = Random.Range(0, Animal.Length);


        MyAudio.clip = Animal[CurrentIndex];
        MyAudio.Play();


    }
    //public void CORECTANSER()
    //{
    //    CURRECT.Play();
    //}

    //public void RONGANSER()
    //{
    //    RONG.Play();


    //}

    public void CheckAnswer(int index)
    {
        if (index == CurrentIndex)
        {
            //right answer
            print("wwigt Answer");

            SFXSource.clip = Wright;
            SFXSource.Play();
        }
        else
        {
            //wrong answer
            print("Wrong Answer");
            SFXSource.clip = Wrong;
            SFXSource.Play();
        }
    }
}