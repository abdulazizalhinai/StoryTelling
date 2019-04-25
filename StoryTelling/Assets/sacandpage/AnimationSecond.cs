using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSecond : PlayerManager
{
    // Start is called before the first frame update
    void Start()
    {
        Init();

        Walk();
    }

    public override void FinishedWalking()
    {
        Walk();
    }
    public override void FinishedWave()
    {
        Idle();
    }
}
