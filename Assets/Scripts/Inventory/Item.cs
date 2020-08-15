using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int ID { get; set; }
    public string Name { get; set; }
    public ItemType Type { get; set; }

    public enum ItemType
    {
        //食物，药品
        //电池
    }
}
