using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeAnimation : MonoBehaviour
{
    bool blink;
    float timer = 0;

    private void Start()
    {
        Invoke("Blink", 4);
    }

    private void Update()
    {
        if (blink)
        {
            timer += Time.deltaTime * Mathf.PI * 2;
            print(timer);
            transform.localScale = new Vector3(1, 1, Mathf.Abs(Mathf.Cos(timer)));

            if (timer > Mathf.PI)
            {
                blink = false;
            }
        }
    }

    void Blink()
    {
        timer = 0;
        blink = true;

        Invoke("Blink", Random.Range(3.0f, 5.0f));
    }
}
