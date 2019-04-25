using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tail : PartAnimation
{
    public override void Walk()
    {
        transform.localEulerAngles = new Vector3(-90 + Mathf.Cos((Time.time) * 10) * 30, 0, 0);
    }
}
