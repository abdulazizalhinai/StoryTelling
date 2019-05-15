using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
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

            timer += Time.deltaTime * 6;
            transform.position += Vector3.up * Time.deltaTime *8;
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * 0.05f, timer);


            if (timer > 1)
            {
                jump = false;
                GetComponent<Rigidbody>().useGravity = true;
            }
        }

    }

}

