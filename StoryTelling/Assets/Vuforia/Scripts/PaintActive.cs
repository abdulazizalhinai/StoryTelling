using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintActive : MonoBehaviour
{
    public GameObject gameObject1;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform item in transform)
        {
            item.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
