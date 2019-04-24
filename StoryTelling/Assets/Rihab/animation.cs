using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public enum aState
{
    Idle,
    walking,
}

public class animation : MonoBehaviour
{
    float counter;
    public aState currentState;
    Animator yarboa;
    float moveSpeed = 1;
    public Transform[] WayPoints;
    private int index = 0;
    Rigidbody RB;
    public float Speed;

    PartAnimation[] AllParts;

    public Text Debug;

    float currentAngle;
    //private void OnEnable()
    //{
    //    switch (currentState)
    //    {
    //        case aState.Idle:
    //            yarboa.SetTrigger("Wave");
    //            break;
    //        case aState.walking:
    //            yarboa.SetTrigger("Walk");
    //            break;
    //        default:
    //            break;
    //    }
    //}

    void Start()
    {
        counter = 3f;
        yarboa = GetComponent<Animator>();

        RB = GetComponent<Rigidbody>();

        AllParts = GetComponentsInChildren<PartAnimation>();

        PlayAnim(AllAnimations.Wave);
    }

    void Update()
    {
        
        switch (currentState)
        {
            case aState.Idle:
                counter -= Time.deltaTime;

                if (counter < 0)
                {
                    currentState = aState.walking;

                    PlayAnim(AllAnimations.Walk);
                }
                break;
            case aState.walking:

                Vector3 wayPointDirection = (WayPoints[index].localPosition - transform.localPosition).normalized;
                
                float angle = Mathf.Atan2(wayPointDirection.x, wayPointDirection.z) * Mathf.Rad2Deg;
                transform.Rotate(0, Mathf.Clamp(wrapAngle(angle - transform.localEulerAngles.y), Time.deltaTime * -120, Time.deltaTime * 120), 0, Space.Self);

                RB.velocity = Speed * transform.forward;
                Debug.text = (index + " " + Vector3.Distance(transform.position, WayPoints[index].position));
                if (Vector3.Distance(transform.position, WayPoints[index].position) < 1.5f)
                {
                    print(index);
                    index++;

                    if (WayPoints.Length == index)
                    {
                        index = 0;
                        currentState = aState.Idle;
                        RB.velocity = Vector3.zero;

                        counter = 3;

                        PlayAnim(AllAnimations.Wave);
                    }
                }

                break;
            default:
                break;
        }
    }

    float wrapAngle(float angle)
    {
        if (angle > 180)
            angle -= 360;
        if (angle < -180)
            angle += 360;

        return angle;
    }

    private void PlayAnim(AllAnimations anim)
    {
        foreach (var item in AllParts)
        {
            item.CurrentAnimation = anim;
        }
    }
}
