using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lageleft : PartAnimation

{
    public bool IsLeft;
    Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    public override void Walk()
    {
        transform.localPosition = new Vector3(0, Mathf.Cos((Time.time * 5) + (IsLeft ? Mathf.PI : 0)) * 0.02f, 0) + originalPosition;
    }


}
