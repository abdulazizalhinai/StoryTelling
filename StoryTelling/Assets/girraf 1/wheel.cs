﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localRotation = new Vector3(0,1,0);
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }
}
