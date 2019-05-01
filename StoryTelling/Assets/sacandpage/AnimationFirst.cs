using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFirst : PlayerManager
{
    Rigidbody rigidbody1;​
    bool jump = true;​
    float timer = 0;​
    public GameObject effect1jump;​
    bool effect = true;​
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
