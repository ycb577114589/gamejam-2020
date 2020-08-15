using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Item: MonoBehaviour
{
    public int ID { get; set; }
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public ItemQuality Quality { get; set; }
    public Item()
    {

    }
    public Item(int id,string name,ItemType type,ItemQuality quality)
    {
        this.ID = id;
        this.Name = name;
        this.Type = type;
        this.Quality = quality;
    }
    public enum ItemType
    {
        food,
        drug,
        battery,
        other
    }
    public enum ItemQuality
    {
        common,
        rare,
        epic
    }
}
