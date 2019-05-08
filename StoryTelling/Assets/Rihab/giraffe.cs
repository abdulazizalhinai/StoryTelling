using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giraffe : MonoBehaviour
{
    bool jump = true;
    float timer = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (jump == true)
        {

            timer += Time.deltaTime * 2;
            transform.position += Vector3.up * Time.deltaTime * 7;
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * 0.2f, timer);


            if (timer > 1)
            {
                jump = false;
                GetComponent<Rigidbody>().useGravity = true;
            }
        }

    }

}
