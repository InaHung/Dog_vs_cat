using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleAttack : Weapon
{

    public List<MultipleAttackWeapon> myWeapons = new List<MultipleAttackWeapon>();

    public void Awake()
    {
        gameObject.SetActive(false);
    }

    public override void SetPlayer(Players player)
    {
        base.SetPlayer(player);


    }
    public override void Update()
    {
        foreach (var weapon in myWeapons)
        {
            if (weapon.hasWeaponThrowing == false || weapon.rigidbody2D.velocity != new Vector2(0f, 0f))
                return;
        }
        StateMachine.ChangeNextPlayer();
        gameObject.SetActive(false);
    }
    public override void MoveWeapon(float strength)
    {
        foreach (var weapon in myWeapons)
        {
            weapon.rigidbody2D.simulated = true;
            weapon.rigidbody2D.gravityScale = 1;
            weapon.rigidbody2D.velocity = moveDirection * strength;
            weapon.hasWeaponThrowing = true;
        }


    }
    public override void ResetWeapon()
    {
        foreach (var weapon in myWeapons)
        {


            weapon.rigidbody2D.gravityScale = 0;
            weapon.hasWeaponThrowing = false;
            weapon.rigidbody2D.simulated = false;
            weapon.hasAttacked = false;
        }
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {


    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {

    }




}
