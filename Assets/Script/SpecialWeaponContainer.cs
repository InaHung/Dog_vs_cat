using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/SpecialWeaponContainer")]
public class SpecialWeaponContainer : ScriptableObject
{
    public SpecialWeaponSettings[] settings;
}

[System.Serializable]
public class SpecialWeaponSettings
{
    public string weaponName;
    public Weapon weapon;
}
