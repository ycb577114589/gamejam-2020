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
                intro += "光线长度升级 更远距离";
                break;
            case 1:
                intro += "光线宽度升级 更广范围";
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
                    print("AddLength");
                    playerWeaponSys.AddLength();
                }
                else if(ID==1)
                {
                    print("AddWidth");
                    playerWeaponSys.AddWidth();
                }
                buff = true;
                deBuff = false;
            }
        }
        else if(gameObject.transform.parent.tag=="Inventory")
        {
            //此时是物品还在面板上，什么都不要调用
        }
        else
        {//没装备上
            print("debug");
            if(deBuff==false)
            {
                if(ID==0)
                {
                    print("ReduceLength");
                    playerWeaponSys.ReduceLength();
                }
                else if(ID==1)
                {
                    print("ReduceWidth");
                    playerWeaponSys.ReduceWidth();
                }
                buff = false;
                deBuff = true;
            }
        }
    }

}
