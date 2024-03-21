using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleAttackWeapon : Weapon
{
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Players players = collision.transform.GetComponent<Players>();
        if (players != null)
        {
            if (players.playerType != playerType&&!hasAttacked)
            {
                hasAttacked = true;
                players.playerAttacked(damage);
            }
        }
        if (collision.gameObject.tag == "floor")
        {
            gameObject.SetActive(false);
        }
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            gameObject.SetActive(false);
        }
    }

    public override void ResetWeapon()
    {

    }





}
