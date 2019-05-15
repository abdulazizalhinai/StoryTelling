using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenColors : MonoBehaviour
{
    public AudioClip Color;
    public GameObject color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        SoundManager.instance.PlaySingle(Color); 
        color.SetActive(true);
    }
}
