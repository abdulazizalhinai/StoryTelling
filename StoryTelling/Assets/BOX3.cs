using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX3 : MonoBehaviour
{
    public AudioSource CURRECT;
    public AudioSource RONG;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ANSER()
    {
        if (PlayerPrefs.GetInt("BOX3", 0) == 1)
        {
            CURRECT.Play();
        }
        else
        {
            RONG.Play();
        }


    }
    public void CORECTANSER()
    {


        CURRECT.Play();





    }

    public void RONGANSER()
    {
        RONG.Play();


    }
}