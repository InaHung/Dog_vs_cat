using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StrengthBar : MonoBehaviour
{
    public Slider slider;


    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void SetMaxStrength(float strength)
    {
        slider.maxValue = strength;
        slider.value = 0;
    }


    public void SetStrength(float strength)
    {
        slider.value = strength;
    }




}


