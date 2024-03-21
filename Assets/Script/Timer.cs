using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public SpriteRenderer renderer;
    private void Awake()
    {
        renderer.enabled = false;
    }

    public void StartCountDown(Action _callBack)
    {
        StartCoroutine(Timing(_callBack));
        StartCoroutine(fiveSeconds());
    }


    IEnumerator Timing(Action _callBack)
    {
        
        yield return new WaitForSeconds(10f);
        ResetTimer();
        _callBack();
    }
    IEnumerator fiveSeconds()
    {
       
        yield return new WaitForSeconds(5f);
        renderer.enabled=true;
    }

    
    public void ResetTimer()
    {
        renderer.enabled=false;
        StopAllCoroutines();
    }


}
