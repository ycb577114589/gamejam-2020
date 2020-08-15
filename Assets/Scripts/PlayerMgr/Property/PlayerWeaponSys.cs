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

    private void Start()
    {
        curWeapon = GameObject.FindGameObjectWithTag("Weapon");
        curWeapon.transform.SetParent(transform);
    }
    void ChangeWeapon()
    {
        Vector3 temp;
        switch (buffLength)
        {
            case 0:
                switch(buffWidth)
                {
                    case 0:
                        temp = curWeapon.transform.position;
                        GameObject.Instantiate(weapons[0], temp, Quaternion.identity, transform);
                        break;
                    case 1:
                        temp = curWeapon.transform.position;
                        GameObject.Instantiate(weapons[3], temp, Quaternion.identity, transform);
                        break;
                }
                break;
            case 1:
                switch (buffWidth)
                {
                    case 0:
                        temp = curWeapon.transform.position;
                        GameObject.Instantiate(weapons[1], temp, Quaternion.identity, transform);
                        break;
                    case 1:
                        temp = curWeapon.transform.position;
                        GameObject.Instantiate(weapons[4], temp, Quaternion.identity, transform);
                        break;
                }
                break;
            case 2:
                switch (buffWidth)
                {
                    case 0:
                        temp = curWeapon.transform.position;
                        GameObject.Instantiate(weapons[2], temp, Quaternion.identity, transform);
                        break;
                    case 2:
                        temp = curWeapon.transform.position;
                        GameObject.Instantiate(weapons[5], temp, Quaternion.identity, transform);
                        break;
                }
                break;
        }
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
