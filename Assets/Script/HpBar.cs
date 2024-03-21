using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Slider slider;
    public Text text;
    public Button restartButton;
    public string whoWin;
    void Awake()
    {
        text.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }
    public void SetMaxHp(int Hp)
    {
        slider.maxValue = Hp;
        slider.value = Hp;
    }
    public void SetHp(int Hp)
    {
        slider.value = Hp;
        if (Hp <= 0)
        {
            StateMachine.ChangeState(State.Complete);
            text.text = whoWin;
            text.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }
}
