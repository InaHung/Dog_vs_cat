using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplePlayer : Weapon
{
    public List<Vector3> myPosition = new List<Vector3>();

    public override void SetPlayer(Players player)
    {
        base.SetPlayer(player);
        ChoosePosition();

    }
    public void ChoosePosition()
    {
        int childIndex = 0;
        int listSize = Random.Range(0, myPosition.Count);
        myPlayer.transform.position = myPosition[listSize];
        for (int i = 0; i < myPosition.Count; i++)
        {
            if (i == listSize)
                continue;
            else
            {
                transform.GetChild(childIndex).transform.position = myPosition[i];
                childIndex++;
            }
        }
    }
    public override void ResetWeapon()
    {
        
    }






}
