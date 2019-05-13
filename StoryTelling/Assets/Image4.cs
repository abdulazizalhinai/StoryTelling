using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image4 : MonoBehaviour

{
    float timer = 0;
    public AudioClip therdPage;
    public AudioClip therdGame;
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlaySingle(therdPage);


    }

    // Update is called once per frame
    void Update()
    {
        timer += 0.5f;
        print(timer);
        if (timer == 200)
        {
            SoundManager.instance.PlaySingle(therdGame);
            print("4555");
        }
    }
}
