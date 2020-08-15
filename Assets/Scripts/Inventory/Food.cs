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
    public string intro="";
     public void SetFood(int id, Inventory.ItemQuality quality, Inventory.FoodState state)
    {
        ID = id;
        this.Quality = quality;
        this.State = state;
        //依据传入的参数选择物品说明
        switch (id)
        {
            case 0:
                switch (Quality)
                    {
                    case Inventory.ItemQuality.common:
                        intro += "普通冰淇淋 3S内回复10HP";
                        break;
                    case Inventory.ItemQuality.rare:
                        intro += "稀有冰淇淋 3S内回复20HP";
                        break;
                    case Inventory.ItemQuality.epic:
                        intro += "至尊冰淇淋 3S内回复30HP";
                        break;
                    }
                break;
            case 1:
                switch (Quality)
                {
                    case Inventory.ItemQuality.common:
                        intro += "普通饭团 3S内回复30HP";
                        break;
                    case Inventory.ItemQuality.rare:
                        intro += "稀有饭团 3S内回复40HP";
                        break;
                    case Inventory.ItemQuality.epic:
                        intro += "至尊饭团 3S内回复50HP";
                        break;
                }
                break;
            case 2:
                switch (Quality)
                {
                    case Inventory.ItemQuality.common:
                        intro += "普通胡萝卜 3S内回复20HP";
                        break;
                    case Inventory.ItemQuality.rare:
                        intro += "稀有胡萝卜 3S内回复30HP";
                        break;
                    case Inventory.ItemQuality.epic:
                        intro += "至尊胡萝卜 3S内回复40HP";
                        break;
                }
                break;
            case 3:
                switch (Quality)
                {
                    case Inventory.ItemQuality.common:
                        intro+= "普通鸡腿 3S内回复40HP";
                        break;
                    case Inventory.ItemQuality.rare:
                        intro += "稀有鸡腿 3S内回复50HP";
                        break;
                    case Inventory.ItemQuality.epic:
                        intro+= "至尊鸡腿 3S内回复60HP";
                        break;
                }
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
            Use();//双击使用
        }
        time = Time.time;
    }
    
    public void Use()
    {
        print(intro);
        print("food的Use事件");
    }
}
