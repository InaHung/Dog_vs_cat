using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaximunWeapon : Weapon
{
    public Vector3 localScaleMaximun;


  
    public override void ResetWeapon()
    {
        transform.localScale = localScaleMaximun;
        base.ResetWeapon();
    }

}
