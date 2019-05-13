using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image3 : MonoBehaviour
{
    float timer = 0;
    public AudioClip ScondPage;
    public AudioClip ScondGame;
    // Start is called before the first frame update
    void Start()
    {

        SoundManager.instance.PlaySingle(ScondPage);
    }

    // Update is called once per frame
    void Update()
    {
        timer += 0.5f;
        print(timer);
        if (timer == 200)
        {
            SoundManager.instance.PlaySingle(ScondGame);
            print("4555");
        }
    }
}
