using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MysteryBox : MonoBehaviour
{
    public GameObject root;
    public SpecialWeaponContainer specialWeaponContainerDog;
    public SpecialWeaponContainer specialWeaponContainerCat;
    public Players dog;
    public Players cat;
    
    private void Awake()
    {
        root.SetActive(true);
    }

    public void OnMysteryBoxClick()
    {
        Players curPlayer = null;
        SpecialWeaponContainer specialWeaponContainer = null;
        if (StateMachine.curState == State.MesteryDog)
        {
            specialWeaponContainer = specialWeaponContainerDog;
            curPlayer = dog;
        }

        else if (StateMachine.curState == State.MesteryCat)
        {
            specialWeaponContainer = specialWeaponContainerCat;
            curPlayer = cat;
        }
        if (specialWeaponContainer != null)
        {
            int randomIndex = Random.Range(0, specialWeaponContainer.settings.Length);
            Weapon mysteryWeapon = specialWeaponContainer.settings[randomIndex].weapon;
            curPlayer.SetMysteryWeapon(mysteryWeapon);
            if (curPlayer == dog)
                StateMachine.ChangeState(State.MesteryCat);
            else if (curPlayer == cat)
            {
                StateMachine.ChangeState(State.DogTurn);
                root.SetActive(false);
            }
        }

    }





}
