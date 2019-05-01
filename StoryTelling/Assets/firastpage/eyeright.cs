using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeright :PartAnimation
{
    public bool IsLeft;
    public override void Walk()
    {
        transform.localEulerAngles = new Vector3(0,80 + Mathf.Cos((Time.time + (IsLeft ? Mathf.PI : 0) * 5) * 30),0);
    }

}

