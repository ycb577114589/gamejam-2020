using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 电池
/// </summary>
public class Battery : MonoBehaviour, IPointerClickHandler
{
    public int ID;
    public UnityEvent leftClick;
    private float time;
    private Inventory.ItemQuality Quality;
    public string intro="";

    public void SetBattery(int id, Inventory.ItemQuality quality)
    {
        ID = id;
        this.Quality = quality;
        switch (Quality)
        {
            case Inventory.ItemQuality.common:
                intro += "普通电池 立即回复电量30";
                break;
            case Inventory.ItemQuality.rare:
                intro += "稀有电池 立即回复电量50";
                break;
            case Inventory.ItemQuality.epic:
                intro += "至尊电池 立即回复电量70";
                break;
        }
    }
    void Start()
    {
        leftClick.AddListener(new UnityAction(DoubleLeftClick));
        time = Time.time;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            leftClick.Invoke();
        }
    }
    public void DoubleLeftClick()
    {
        if (Time.time - time <= 0.3f)
        {
            Use();
        }
        time = Time.time;
    }
    public void Use()
    {
        print("battery的Use事件");
    }
}

