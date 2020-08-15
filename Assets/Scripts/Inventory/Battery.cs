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

    public void SetBattery(int iD, Inventory.ItemQuality quality)
    {
        ID = iD;
        this.Quality = quality;
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

