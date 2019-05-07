using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyAnimation : PartAnimation
{
    Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.localPosition;
    }

    public override void Idle()
    {
        transform.localPosition = originalPos + new Vector3(0, Mathf.Cos(Time.time * 2) * 0.02f, 0);
    }
    //public override void yes()
    //{
    //    transform.localEulerAngles = new Vector3(-90, 0, -90 + Mathf.Cos(Time.time * 2));
    //}
}
