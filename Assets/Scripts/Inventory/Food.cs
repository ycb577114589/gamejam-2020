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
    public PlayerPropertySys playerProperty;

    int hp = 0;
    float hpRiseTime = 0;

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
                        hp = 10;
                        hpRiseTime = 3f;
                        break;
                    case Inventory.ItemQuality.rare:
                        intro += "稀有冰淇淋 3S内回复20HP";
                        hp =20;
                        hpRiseTime = 3f;
                        break;
                    case Inventory.ItemQuality.epic:
                        intro += "至尊冰淇淋 3S内回复30HP";
                        hp = 30;
                        hpRiseTime = 3f;
                        break;
                    }
                break;
            case 1:
                switch (Quality)
                {
                    case Inventory.ItemQuality.common:
                        intro += "普通饭团 3S内回复30HP";
                        hp = 30;
                        hpRiseTime = 3f;
                        break;
                    case Inventory.ItemQuality.rare:
                        intro += "稀有饭团 3S内回复40HP";
                        hp = 40;
                        hpRiseTime = 3f;
                        break;
                    case Inventory.ItemQuality.epic:
                        intro += "至尊饭团 3S内回复50HP";
                        hp = 50;
                        hpRiseTime = 3f;
                        break;
                }
                break;
            case 2:
                switch (Quality)
                {
                    case Inventory.ItemQuality.common:
                        intro += "普通胡萝卜 3S内回复20HP";
                        hp = 20;
                        hpRiseTime = 3f;
                        break;
                    case Inventory.ItemQuality.rare:
                        intro += "稀有胡萝卜 3S内回复30HP";
                        hp = 30;
                        hpRiseTime = 3f;
                        break;
                    case Inventory.ItemQuality.epic:
                        intro += "至尊胡萝卜 3S内回复40HP";
                        hp = 40;
                        hpRiseTime = 3f;
                        break;
                }
                break;
            case 3:
                switch (Quality)
                {
                    case Inventory.ItemQuality.common:
                        intro+= "普通鸡腿 3S内回复40HP";
                        hp = 40;
                        hpRiseTime = 3f;
                        break;
                    case Inventory.ItemQuality.rare:
                        intro += "稀有鸡腿 3S内回复50HP";
                        hp = 50;
                        hpRiseTime = 3f;
                        break;
                    case Inventory.ItemQuality.epic:
                        intro+= "至尊鸡腿 3S内回复60HP";
                        hp = 60;
                        hpRiseTime = 3f;
                        break;
                }
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
            Use();//双击使用
        }
        time = Time.time;
    }
    
    public void Use()
    {
        print(intro);
        print("food的Use事件");
        playerProperty.ChangeValue(PlayerPropertySys.PropertyValueType.Hp, hp, hpRiseTime);
    }
}
