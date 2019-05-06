﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ears : PartAnimation
{

    public bool IsLeft;


    public override void Walk()
    {
        transform.localEulerAngles = new Vector3(-90 + Mathf.Cos((Time.time * 5) + (IsLeft ? Mathf.PI : 0)) * 30, 0, 0);
    }

    public override void Idle()
    {
        transform.localEulerAngles = new Vector3( Mathf.Cos((Time.time * 2) + (IsLeft ? Mathf.PI : 0)) * 15, 0, 0);
    }

}
