using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Drug : MonoBehaviour, IPointerClickHandler
{
    public int ID;
    private Inventory.ItemQuality Quality;

    public UnityEvent leftClick;
    private float time;

    public void SetDrug(int iD, Inventory.ItemQuality quality)
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
        print("drug的Use事件");
    }
}
