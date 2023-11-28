using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintingText : MonoBehaviour
{
    string text;

    void Start()
    {
        text = GetComponent<Text>().text;
        GetComponent<Text>().text = "";
        StartCoroutine(TextCoroutine());
    }

    IEnumerator TextCoroutine()
    {
        foreach (char abc in text)
        {
            GetComponent<Text>().text += abc;
            yield return new WaitForSeconds(0.01f);
        }
    }
    
}
