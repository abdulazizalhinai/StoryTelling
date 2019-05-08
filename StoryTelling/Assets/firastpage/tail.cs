using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tail : PartAnimation
{
    public override void Walk()
    {
        transform.localEulerAngles = new Vector3(-80 + Mathf.Cos((Time.time) * 5) * 10, 0, 0);
    }
}
