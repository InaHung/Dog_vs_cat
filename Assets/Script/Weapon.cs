using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : MonoBehaviour
{
    public Players myPlayer;
    public PlayerType playerType;
    public new Rigidbody2D rigidbody2D;
    public bool hasWeaponThrowing;
    public Vector3 localposition;
    public Vector3 moveDirection;
    public int damage;
    public int canUseCount = 1;
    public bool defensiveWeapon=false;
    public bool hasAttacked;
    private void Awake()
    {
        ResetWeapon();
    }
    public virtual void Update()
    {
        if (hasWeaponThrowing == true && rigidbody2D.velocity == new Vector2(0f, 0f))
        {
            StateMachine.ChangeNextPlayer();
            ResetWeapon();
        }

    }

    public virtual void SetPlayer(Players player)
    {
        myPlayer = player;
    }
    public virtual void MoveWeapon(float strength)
    {
        rigidbody2D.simulated = true;
        rigidbody2D.gravityScale = 1;
        rigidbody2D.velocity = moveDirection * strength;
        hasWeaponThrowing = true;
    }

    public virtual void ResetWeapon()
    {
        gameObject.SetActive(false);
        transform.localPosition = localposition;
        rigidbody2D.gravityScale = 0;
        hasWeaponThrowing = false;
        rigidbody2D.simulated = false;
        hasAttacked = false;
    }
   
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Players players = collision.transform.GetComponent<Players>();
        if (players != null)
        {
            if (players.playerType != playerType)
            {
                if (hasAttacked)

                    return;
                hasAttacked = true;
                players.playerAttacked(damage);

            }
        }
        if (collision.gameObject.tag == "floor")
        {
            StateMachine.ChangeNextPlayer();
            ResetWeapon();
        }
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            StateMachine.ChangeNextPlayer();
            ResetWeapon();
        }
    }



}


