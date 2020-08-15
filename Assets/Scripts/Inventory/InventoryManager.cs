using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;

public class InventoryManager : MonoBehaviour
{
    public GameObject go_Inventory;
    public Inventory inventory;
    private void Start()
    {
        //打开箱子生成面板和物品的调用方法：

        //GameObject go= GameObject.Instantiate(go_Inventory, transform.position, Quaternion.identity, transform);//先生成InventoryGameObject
        //inventory = go.GetComponent<Inventory>();//获取脚本后，调用SetInventory函数，这个函数有3个重载，通过传入不同的参数可以生成不同的物品
        //例子1：生成食物：需要传入：物品类别，物品编号（0~3），物品品质，物品目前的状态
        //0~3号分别是冰淇淋，胡萝卜，饭团，鸡腿
        //这里生成了普通鸡腿
        //iv.SetInventory(Inventory.ItemType.food, 3, Inventory.ItemQuality.common, Inventory.FoodState.good);

        //例子2：生成电池：需要传入：物品类别，物品编号（只有0号），物品品质
        //这里生成了一个稀有电池
        //iv.SetInventory(Inventory.ItemType.battery, 0, Inventory.ItemQuality.rare);

        //例子3：生成了药品，升级品，恶搞物品：需要传入物品类别，物品编号（只要药品有0~2号，其他的目前只有0号）
        //这里生成了一个大型药箱
        //iv.SetInventory(Inventory.ItemType.drug, 2);
    }
    public void CreatePanel(ItemType type, int id, ItemQuality quality, FoodState state = FoodState.good)
    {
        GameObject go = GameObject.Instantiate(go_Inventory, transform.position, Quaternion.identity, transform);//先生成InventoryGameObject
        inventory = go.GetComponent<Inventory>();//获取脚本后，调用SetInventory函数，这个函数有3个重载，通过传入不同的参数可以生成不同的物品
        if(type== Inventory.ItemType.food)
        {
            inventory.SetInventory(type,id , quality, Inventory.FoodState.good);
        }
        else
        {
            inventory.SetInventory(type, id, quality);
        }
    }
}

