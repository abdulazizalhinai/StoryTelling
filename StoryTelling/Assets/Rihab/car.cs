using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
   public AudioSource sound1;
    public AudioClip clip;
    bool jump = true,sound=true;
    float timer = 0,timertwo=0;

    private void Start()
    {
        sound1= GetComponent<AudioSource>();
        sound1.clip = clip;

    }

    void Update()
    {
      
            while (jump == true)
            {

                timer += Time.deltaTime * 2;
                transform.position += Vector3.up * Time.deltaTime * 7;
                transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * 0.02f, timer);


                if (timer > 1)
                {
                    jump = false;
                    GetComponent<Rigidbody>().useGravity = true;
                }
            }
            sound1.Play();

            sound = false;

            if (sound == false)
                sound1.Pause();
        
    }

}

