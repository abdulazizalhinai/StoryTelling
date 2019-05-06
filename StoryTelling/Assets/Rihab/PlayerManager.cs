using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public enum aState
{
    Idle,
    walking,
    Wave,
    stands,
    yas,
    no,
}

public class PlayerManager : MonoBehaviour
{
    internal float counter;
    public aState currentState;
    Animator yarboa;
    float moveSpeed = 1;
    public Transform[] WayPoints;
    internal int index = 0;
    internal Rigidbody RB;
    public float Speed;
    PartAnimation[] AllParts;
    public Text Debug;
    float currentAngle;
    public Action walkFinished;
    public Action waveFinished;
    protected virtual void Start()
    {
        Init();
    }
    public void Init()
    {
        yarboa = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();
        AllParts = GetComponentsInChildren<PartAnimation>();

        walkFinished = FinishedWalking;
        waveFinished = FinishedWave;
    }

    protected virtual void Update()
    {

        switch (currentState)
        {
            case aState.Idle:

                break;
            case aState.walking:
                Vector3 wayPointDirection = (WayPoints[index].localPosition - transform.localPosition).normalized;
                float angle = Mathf.Atan2(wayPointDirection.x, wayPointDirection.z) * Mathf.Rad2Deg;
                transform.Rotate(0, Mathf.Clamp(wrapAngle(angle - transform.localEulerAngles.y), Time.deltaTime * -120, Time.deltaTime * 120), 0, Space.Self);

                RB.velocity = Speed * transform.forward;

                if (Vector3.Distance(transform.position, WayPoints[index].position) < 1f)
                {
                    print(index);
                    index++;

                    if (WayPoints.Length == index)
                    {
                        index = 0;
                        walkFinished.Invoke();
                        //currentState = aState.Idle;
                    }
                }

                break;
            case aState.Wave:

                counter -= Time.deltaTime;

                if (counter < 0)
                {
                    waveFinished.Invoke();
                }
                break;
            default:
                break;
        }
    }

    public void Walk()
    {
        currentState = aState.walking;
        PlayAnim(AllAnimations.Walk);
    }

    public void Wave(float time)
    {
        counter = time;

        RB.velocity = Vector3.zero;
        currentState = aState.Wave;
        PlayAnim(AllAnimations.Wave);

    }

    public void Idle()
    {

        currentState = aState.Idle;
        RB.velocity = Vector3.zero;
        PlayAnim(AllAnimations.Idle);

    }
    public void yas()
    {

        currentState = aState.Idle;
        RB.velocity = Vector3.zero;
        PlayAnim(AllAnimations.Idle);

    }
    float wrapAngle(float angle)
    {
        if (angle > 180)
            angle -= 360;
        if (angle < -180)
            angle += 360;

        return angle;
    }

    public void PlayAnim(AllAnimations anim)
    {
        foreach (var item in AllParts)
        {
            item.CurrentAnimation = anim;
        }
    }

    public virtual void FinishedWalking()
    {

    }

    public virtual void FinishedWave()
    {

    }
}
