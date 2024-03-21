using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimumPlayer : Weapon
{
    public float miniPercent;

    public override void SetPlayer(Players player)
    {
        base.SetPlayer(player);
        Minimum();
    }
    public void Minimum()
    {
        myPlayer.transform.localScale = myPlayer.originSize/ miniPercent;
        
    }
   
}
