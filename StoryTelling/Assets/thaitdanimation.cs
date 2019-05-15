using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thaitdanimation : PlayerManager
{
    Rigidbody rigidbody1;
    bool jump = true;
    float timer = 0;
    public GameObject effect1jump;
    bool effect = true;
    public AudioClip FirstGame;
    public AudioClip HelpMe;


    protected override void Start()
    {

        Init();
        //Idle();
        Wave(8.5f);

        SoundManager.instance.PlaySingle(FirstGame);
    }
    public override void FinishedWave()

    {
        //Wave(Mathf.Infinity);
        Idle();
        SoundManager.instance.PlaySingle(HelpMe);
    }


    protected override void Update()
    {
        if (effect == true)
        {

            if (PlayerPrefs.GetInt("effect") == 1)
            {
                Instantiate(effect1jump, transform.position, transform.rotation);
                effect = false;
            }
        }
        base.Update();
        if (jump == true)
        {

            timer += Time.deltaTime * 2;
            transform.position += Vector3.up * Time.deltaTime * 7;
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * 0.3f, timer);


            if (timer > 1)
            {
                jump = false;
                GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!jump && collision.collider.tag == "Ground")
            Walk();
    }

}

