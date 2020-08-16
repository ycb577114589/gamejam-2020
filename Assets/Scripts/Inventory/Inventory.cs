using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public int ID;
    public ItemType Type;
    public ItemQuality Quality;
    public FoodState State;

    public bool panelShow = true;
    public GameObject boxPanel;//开箱的弹窗
    public Text introducrion;//说明文字

    public GameObject[] food;
    public GameObject[] drug;
    public GameObject[] battery;
    public GameObject[] upgrade;
    public GameObject[] other;

    /// <summary>
    /// 药品，升级品，恶搞品的参数函数入口
    /// </summary>
    /// <param name="type">物品的类别，此函数实现Upgrade,Other</param>
    /// <param name="id">物品的编号</param>
    public void SetInventory(ItemType type,int id)
    {
        this.Type = type;
        this.ID = id;
    }
    /// <summary>
    ///电池的参数函数入口
    /// </summary>
    /// <param name="type">物品类别，此处实现battery</param>
    /// <param name="id">物品编号</param>
    /// <param name="quality">物品的品质</param>
    public void SetInventory(ItemType type, int id, ItemQuality quality)
    {
        this.Type = type;
        this.ID = id;
        this.Quality = quality;
    }
    /// <summary>
    /// 食物参数函数入口
    /// </summary>
    /// <param name="type">物品类别，这里只实现food</param>
    /// <param name="id">物品编号</param>
    /// <param name="quality">物品品质</param>
    /// <param name="state">食物目前的状态</param>
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
                introducrion.text = fd.intro;
                break;
            case ItemType.drug:
                go = GameObject.Instantiate(drug[ID], transform.position, Quaternion.identity, this.transform);
                Drug dg = go.GetComponent<Drug>();
                dg = go.GetComponent<Drug>();
                dg.SetDrug(ID);
                introducrion.text = dg.intro;
                break;
            case ItemType.battery:
                go= GameObject.Instantiate(battery[ID], transform.position, Quaternion.identity, this.transform);
                Battery bty = go.GetComponent<Battery>();
                bty.SetBattery(ID, Quality);
                introducrion.text = bty.intro;
                break;
            case ItemType.upgrade:
                go= GameObject.Instantiate(upgrade[ID], transform.position, Quaternion.identity, this.transform);
                Upgrade ud = go.GetComponent<Upgrade>();
                ud.SetUpgrade(ID);
                introducrion.text = ud.intro;
                break;
            case ItemType.other:
                go= GameObject.Instantiate(upgrade[ID], transform.position, Quaternion.identity, this.transform);
                Other ot = go.GetComponent<Other>();
                ot.SetOther(ID);
                introducrion.text = ot.intro;
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
