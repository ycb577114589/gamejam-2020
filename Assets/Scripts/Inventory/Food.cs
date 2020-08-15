using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Food : MonoBehaviour,IPointerClickHandler
{
    public int ID;
    private Inventory.ItemQuality Quality;
    private Inventory.FoodState State;
    public UnityEvent leftClick;
    private float time;
     public void SetFood(int iD, Inventory.ItemQuality quality, Inventory.FoodState state)
    {
        ID = iD;
        this.Quality = quality;
        this.State = state;
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
        print("ID:" + ID + "Quality:" + Quality + "State:" + State);
        print("food的Use事件");
    }
}
