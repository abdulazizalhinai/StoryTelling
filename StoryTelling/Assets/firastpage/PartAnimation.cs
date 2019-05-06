using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AllAnimations
{
    Idle,
    Wave,
    Walk,
    No,
    Yes
}

public class PartAnimation : MonoBehaviour
{
    internal AllAnimations CurrentAnimation;

    public float Speed = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentAnimation)
        {
            case AllAnimations.Idle:
                Idle();
                break;
            case AllAnimations.Wave:
                Wave();
                break;
            case AllAnimations.Walk:
                Walk();
                break;
            case AllAnimations.No:
                break;
            case AllAnimations.Yes:
                break;
            default:
                break;
        }
    }

    public virtual void Wave()
    {

    }

    public virtual void Walk()
    {

    }

    public virtual void Idle()
    {

    }
    public virtual void yes()
    {

    }
}
