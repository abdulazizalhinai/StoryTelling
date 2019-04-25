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
        Walk();
    }

    // Update is called once per frame
   
    public override void FinishedWalking()
    {
        Walk();
    }
    //public override void FinishedWalking()
    //{
    //    Wave();
    //}

    
}
