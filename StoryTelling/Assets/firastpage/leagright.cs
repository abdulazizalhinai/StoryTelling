using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leagright : PartAnimation
 

{
    public bool IsLeft;
    public override void Walk()
    {
        transform.localPosition = new Vector3(0,  Mathf.Cos((Time.time + (IsLeft ? Mathf.PI : 0)) * 5) * 0.02f, 0);
    }

    //public override void Wave()
    //{
    //    if (!IsLeft)
    //    {
    //        transform.localEulerAngles = new Vector3(90 + Mathf.Cos(Time.time * 10) * 30, 0, 0);
    //    }
    //}
}
