using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int ID;
    public ItemType Type;
    public ItemQuality Quality;
    public FoodState State;

    public bool panelShow = true;
    public GameObject boxPanel;
    public GameObject[] food;
    public GameObject[] drug;
    public GameObject[] battery;
    public GameObject[] upgrade;
    public GameObject[] other;
    /// <summary>
    /// 升级品，恶搞品的参数函数入口
    /// </summary>
    public void SetInventory(ItemType type,int id)
    {
        this.Type = type;
        this.ID = id;
    }
    /// <summary>
    /// 药品，电池的参数函数入口
    /// </summary>
    public void SetInventory(ItemType type, int id, ItemQuality quality)
    {
        this.Type = type;
        this.ID = id;
        this.Quality = quality;
    }
    /// <summary>
    /// 食物参数函数入口
    /// </summary>
    public void SetInventory(ItemType type,int id,ItemQuality quality,FoodState state)
    {
        this.Type = type;
        this.ID = id;
        this.Quality = quality;
        this.State = state;
    }
    private void Start()
    {
        GameObject go;
        switch (Type)//依据传入的数据类型构造面板上的物品
        {
            case ItemType.food:
                go = GameObject.Instantiate(food[ID],transform.position,Quaternion.identity, this.transform);
                Food fd = go.GetComponent<Food>();
                fd.SetFood(ID, Quality, State);
                break;
            case ItemType.drug:
                go = GameObject.Instantiate(drug[ID], transform.position, Quaternion.identity, this.transform);
                Drug dg = go.GetComponent<Drug>();
                dg = go.GetComponent<Drug>();
                dg.SetDrug(ID, Quality);
                break;
            case ItemType.battery:
                go= GameObject.Instantiate(battery[ID], transform.position, Quaternion.identity, this.transform);
                Battery bty = go.GetComponent<Battery>();
                bty.SetBattery(ID, Quality);
                break;
            case ItemType.upgrade:
                go= GameObject.Instantiate(upgrade[ID], transform.position, Quaternion.identity, this.transform);
                Upgrade ud = go.GetComponent<Upgrade>();
                ud.SetUpgrade(ID);
                break;
            case ItemType.other:
                go= GameObject.Instantiate(upgrade[ID], transform.position, Quaternion.identity, this.transform);
                Other ot = go.GetComponent<Other>();
                ot.SetOther(ID);
                break;
        }
    }

    void Update()
    {
        if (panelShow == true)
        {
            boxPanel.SetActive(true);
        }
        else
        {
            Destroy(gameObject,0.1f);
        }
    }
    public void ActivePanel()
    {
        panelShow = true;

    }
    public void DeActivePanel()
    {
        panelShow = false;

    }

    //物品类型
    public enum ItemType
    {
        food,
        drug,
        battery,
        upgrade,
        other
    }
    //物品的质量
    public enum ItemQuality
    {
        common,
        rare,
        epic
    }
    //食物Food的品质，只有调用食物类物品时候要生成
    public enum FoodState
    {
        good,
        bad
    }
}
