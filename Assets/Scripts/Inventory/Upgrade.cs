using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 升级物品
/// </summary>
public class Upgrade : MonoBehaviour
{
    private int ID;
    public string intro="";

    private bool hasEquiped;
    private bool buff=false;
    private bool deBuff=false;

    PlayerWeaponSys playerWeaponSys;
    public void SetUpgrade(int id)
    {
        this.ID = id;
        switch (id)
        {
            case 0:
                intro += "光线长度升级 手电光线长度变得更长";
                break;
            case 1:
                intro += "光线宽度升级 手电光线宽度变得更宽";
                break;
        }
    }
    private void Start()
    {
        playerWeaponSys = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeaponSys>();
    }
    private void Update()
    {
        if(gameObject.transform.parent.tag=="Slot")
        {//装备上
            if(buff==false)
            {
                if(ID==0)
                {
                    playerWeaponSys.AddLength();
                }
                else if(ID==1)
                {
                    playerWeaponSys.AddWidth();
                }
                buff = true;
                deBuff = false;
            }
        }
        else if(gameObject.transform.parent.tag=="Inventory")
        {

        }
        else
        {//没装备上
            if(deBuff==false)
            {
                if(ID==0)
                {
                    playerWeaponSys.ReduceLength();
                }
                else if(ID==1)
                {
                    playerWeaponSys.ReduceWidth();
                }
                buff = false;
                deBuff = true;
            }
        }
    }

}
