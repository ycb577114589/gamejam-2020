using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallItem : MonoBehaviour
{
    public GameObject myContent = null;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InventoryBase item = myContent.GetComponent<InventoryBase>();
            GameRoot.BattleUIMgrInScene.inventory.CreatePanel(item.type, item.id, item.quality, Inventory.FoodState.good);
            //iv.SetInventory(Inventory.ItemType.food, 3, Inventory.ItemQuality.common, Inventory.FoodState.good);
            this.gameObject.SetActive(false);
        }
    }
}