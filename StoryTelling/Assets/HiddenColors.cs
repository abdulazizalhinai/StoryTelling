﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenColors : MonoBehaviour
{
    public GameObject color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        color.SetActive(true);
    }
}
