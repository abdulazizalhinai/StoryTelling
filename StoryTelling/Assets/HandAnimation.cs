﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : PartAnimation
{
    public bool IsLeft;
    public override void Walk()
    {
        transform.localEulerAngles = new Vector3(-90 + Mathf.Cos((Time.time + (IsLeft ? Mathf.PI : 0)) * 5) * 30, 0, 0);
    }

    public override void Wave()
    {
        if (!IsLeft)
        {
            transform.localEulerAngles = new Vector3(90 + Mathf.Cos(Time.time * 5) * 30, 0, 0);
        }
    }
}
