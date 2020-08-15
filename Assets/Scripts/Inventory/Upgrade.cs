using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 升级物品
/// </summary>
public class Upgrade : Item
{
    private int ID;
    public void SetUpgrade(int id)
    {
        this.ID = id;
    }
}
