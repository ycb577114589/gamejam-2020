using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSys : MonoBehaviour
{
    public int mDamage = 0;

    public int buffLength=0;
    public int buffWidth=0;

    public GameObject[] weapons;
    private GameObject curWeapon;

    public PlayerMoveSys playerMove = null;
    public PlayerPropertySys playerProperty = null;
    public void ResetWeaponDamage(int damage)
    {
        mDamage = damage;
    }
    public int Damage
    {
        get
        {
            return mDamage;
        }
    }

    public float showTime = 0.5f;
    private float currenTime = 0f;
    public float useValue = 0f;
    public void UseWeapon()
    {
        if (playerProperty.GetValue(PlayerPropertySys.PropertyValueType.Mp) > 0)
        {
            currenTime = showTime;
            curWeapon.SetActive(true);
            playerProperty.ChangeValue(PlayerPropertySys.PropertyValueType.Mp, -useValue);

        }



    }
    private void Update()
    {
        currenTime -= Time.deltaTime;
        if (currenTime <= 0)
        {
            curWeapon.SetActive(false);
        }
    }
    private void Start()
    {
        curWeapon = GameObject.FindGameObjectWithTag("Weapon");
        curWeapon.transform.SetParent(transform);
    }
    void ChangeWeapon()
    {
        Vector3 temp = curWeapon.transform.position; ;
        if (curWeapon != null)
        {
            Destroy(curWeapon);
            curWeapon = null;
        }
        switch (buffLength)
        {
            case 0:
                switch(buffWidth)
                {
                    case 0:
                        curWeapon=GameObject.Instantiate(weapons[0], temp, Quaternion.identity, transform);
                        break;
                    case 1:
                        curWeapon = GameObject.Instantiate(weapons[3], temp, Quaternion.identity, transform);
                        break;
                }
                break;
            case 1:
                switch (buffWidth)
                {
                    case 0:
                        curWeapon = GameObject.Instantiate(weapons[1], temp, Quaternion.identity, transform);
                        break;
                    case 1:
                        curWeapon = GameObject.Instantiate(weapons[4], temp, Quaternion.identity, transform);
                        break;
                }
                break;
            case 2:
                switch (buffWidth)
                {
                    case 0:
                        curWeapon = GameObject.Instantiate(weapons[2], temp, Quaternion.identity, transform);
                        break;
                    case 2:
                        curWeapon = GameObject.Instantiate(weapons[5], temp, Quaternion.identity, transform);
                        break;
                }
                break;
        }
        playerMove.weapon = curWeapon.transform;
    }

    public void AddLength()
    {
        buffLength++;
        ChangeWeapon();
    }
    public void ReduceLength()
    {
        buffLength--;
        ChangeWeapon();
    }
    public void AddWidth()
    {
        buffWidth++;
        ChangeWeapon();
    }
    public void ReduceWidth()
    {
        buffWidth--;
        ChangeWeapon();
    }
}
