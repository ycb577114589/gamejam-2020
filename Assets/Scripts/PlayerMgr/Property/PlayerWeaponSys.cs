using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSys : MonoBehaviour
{
    public int mDamage = 0;
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
}
