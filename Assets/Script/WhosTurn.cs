using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhosTurn : MonoBehaviour
{
    public Text text;
    private void Awake()
    {
        StateMachine.onStateChange += WhosTurnText;
    }
    public void WhosTurnText(State curState)
    {
        if (text != null)
            text.text = curState.ToString();
    }

}

