using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowQs : MonoBehaviour
{
    private Vector3 tragetPosition;
    private RectTransform PointerRectTransfprom;


    private void Awake()
    {

    }

    private void Update()
    {
        transform.localScale = new Vector3(1 - Mathf.Cos(Time.time * 2) / 12, 1 + Mathf.Cos(Time.time * 2) / 10,0);
    }
}
