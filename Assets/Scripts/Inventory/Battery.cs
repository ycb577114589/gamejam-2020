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

    public PlayerPropertySys playerProperty;
    public int mp = 0;
    public void SetBattery(int id, Inventory.ItemQuality quality)
    {
        ID = id;
        this.Quality = quality;
        switch (Quality)
        {
            case Inventory.ItemQuality.common:
                intro += "普通电池 立即回复电量20";
                mp = 20;
                break;
            case Inventory.ItemQuality.rare:
                intro += "稀有电池 立即回复电量40";
                mp = 40;
                break;
            case Inventory.ItemQuality.epic:
                intro += "至尊电池 立即回复电量60";
                mp = 60;
                break;
        }
    }
    void Start()
    {

        var temp = GameObject.FindWithTag("Player");
        if (temp != null)
        {
            playerProperty = temp.GetComponent<PlayerPropertySys>();
        }
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
        playerProperty.ChangeValue(PlayerPropertySys.PropertyValueType.Mp, mp);
        Destroy(gameObject);
    }
}

