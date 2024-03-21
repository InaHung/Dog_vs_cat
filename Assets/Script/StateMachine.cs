using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateMachine : MonoBehaviour
{
    public static Action<State> onStateChange;
    public static State curPlayer;
    
    public static State curState
    {
        get;
        private set;
    }

   


    private void Awake()
    {
        ChangeState(State.MesteryDog);
        
    }


   
    public static void ChangeState(State nextState)
    {
        if (nextState == curState)
            return;
        curState = nextState;

        if (curState == State.DogTurn || curState == State.CatTurn)
            curPlayer = curState;



        Debug.Log(curState);
        
        if (onStateChange != null)
            onStateChange(curState);
    }
    public static void ChangeNextPlayer()
    {
        if (curPlayer == State.DogTurn)
            ChangeState(State.CatTurn);
        else if(curPlayer == State.CatTurn)
            ChangeState(State.DogTurn);
        

    }

        


    

}



public enum State
{
    
    MesteryDog,
    MesteryCat,
    DogTurn,
    CatTurn,
    Attack,
    Complete
}