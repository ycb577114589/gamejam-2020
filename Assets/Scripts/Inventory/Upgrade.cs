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
}
