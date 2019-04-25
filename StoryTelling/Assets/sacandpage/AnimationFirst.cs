using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFirst : PlayerManager
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
        Wave();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void FinishedWalking()
    {
        Wave();
    }

    
}
