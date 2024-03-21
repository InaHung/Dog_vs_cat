using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public float moveSpeed = 2f;
    public PlayerType playerType;
    public State activeState;
    public float strength;
    public float chargeSpeed = 0.001f;
    public int curHp;
    public int maxHp = 30;
    public HpBar hpBar;
    public Timer timer;
    private Weapon curWeapon;
    public List<Weapon> weapons = new List<Weapon>();
    public float maxStrength;
    public bool hasHpButtonClick;
    public StrengthBar strengthBar;
    public Vector3 originSize;
    Weapon lastWeapon;


    public bool IsMyTurn
    {
        get { return StateMachine.curState == activeState; }
    }
    


    private void Awake()
    {
        curHp = maxHp;
        hpBar.SetMaxHp(maxHp);
        strength = 0;
        strengthBar.SetMaxStrength(maxStrength);
        StateMachine.onStateChange += ResetPlayer;
    }



    void Update()
    {
        if (IsMyTurn)
        {
            if (curWeapon != null)
            {
                Move();
                ModifyStrength(chargeSpeed);
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    Attack(strength);
                    strengthBar.gameObject.SetActive(false);
                }
            }
        }



    }
    public void ResetPlayer(State curState)
    {
        if (IsMyTurn)
        {
            transform.localScale = originSize;
            if (lastWeapon != null && lastWeapon.canUseCount == 0)
                lastWeapon.gameObject.SetActive(false);
        }
    }

    public void OnDestroy()
    {
        StateMachine.onStateChange -= ResetPlayer;
    }

    public void Move()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position = new Vector3(x + moveSpeed, y, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position = new Vector3(x - moveSpeed, y, 0);

    }

    public void ModifyStrength(float count)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            strengthBar.gameObject.SetActive(true);
            strength += count;
            if (strength > maxStrength)
                strength = maxStrength;
            if (strength < 0)
                strength = 0;
            strengthBar.SetStrength(strength);
        }
    }
    public void Attack(float strength)
    {
        lastWeapon = curWeapon;
        curWeapon.MoveWeapon(strength);
        curWeapon = null;
        timer.ResetTimer();
        StateMachine.ChangeState(State.Attack);

    }
    public void ClickWeaponButton(int weaponIndex)
    {
        if (weaponIndex >= weapons.Count)
            return;
        if (curWeapon)
            return;
        if (!IsMyTurn)
            return;
        if (weapons[weaponIndex].canUseCount <= 0)
            return;
        curWeapon = weapons[weaponIndex];
        lastWeapon = curWeapon;
        curWeapon.SetPlayer(this);
        curWeapon.canUseCount--;
        if (curWeapon.defensiveWeapon)
        {
            lastWeapon = curWeapon;
            curWeapon = null;
            StateMachine.ChangeNextPlayer();
        }
        else
        {
            curWeapon.ResetWeapon();
            curWeapon.gameObject.SetActive(true);
            strength = 0;
            timer.StartCountDown(() =>
            {
                Attack(0.8f);
            });
        }
}
public void ClickHpButton(int weaponindex)
{
    if (!IsMyTurn)
        return;
    if (weaponindex >= weapons.Count)
        return;
    if (weapons[weaponindex].canUseCount <= 0)
        return;
    curWeapon = weapons[weaponindex];
    if (curWeapon != null)
    {
        curWeapon.canUseCount--;
        HpBag hpBag = (HpBag)curWeapon;
        curHp += hpBag.Hp;
        if (curHp >= maxHp)
            curHp = maxHp;
        hpBar.SetHp(curHp);
        StateMachine.ChangeNextPlayer();
    }
    curWeapon = null;
}


public void playerAttacked(int damage)
{
    curHp -= damage;
    hpBar.SetHp(curHp);

    if (curHp <= 0)
        curHp = 0;
}
public void SetMysteryWeapon(Weapon mysteryWeapon)
{
    Weapon weapon = Instantiate(mysteryWeapon, transform);
    weapons.Add(weapon);
}




}
public enum PlayerType
{
    Cat,
    Dog,
    Bone,
    Fish,
    Floor
}

