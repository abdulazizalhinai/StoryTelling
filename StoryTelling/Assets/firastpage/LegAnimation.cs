using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegAnimation : PartAnimation
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Walk()
    {
        transform.localEulerAngles = new Vector3(-90 + Mathf.Cos(Time.time * 10) * 15, 0, 0);
    }

    public override void Wave()
    {
        
    }
}
