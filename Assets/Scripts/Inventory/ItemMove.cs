﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 实现物品拖拽移动
/// </summary>
public class ItemMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{   
    private Vector3 beginPos;
    private Image image;
    private Transform inventoryManager;
    private Transform originParent;
    public bool isNew = true;
    void Start()
    {
        image = transform.GetComponent<Image>();
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<Transform>();
        originParent = gameObject.transform.parent.GetComponent<Transform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        beginPos = transform.position;
        transform.SetAsLastSibling();
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.SetParent(inventoryManager);
        transform.position = Input.mousePosition;
        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
            Transform target = eventData.pointerEnter.GetComponent<Transform>();
            if (target.tag == "Slot" && target.GetComponent<Slot>().haveItem == false)//槽是空的
            {
            if (isNew == true)
            {
                Inventory iv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
                iv.panelShow = false;
            }

            //直接放上去
            isNew = false;
                transform.position = target.transform.position;
                transform.SetParent(target.transform);
                transform.localScale = Vector3.one;
                image.raycastTarget = true;
            }
            else if(target.tag=="Item"|| target.tag == "Food")//槽里边有物品
            {
                //若是槽之间物品的移动，则替换物品
                if(isNew==false)
                {
                    target.SetParent(transform.parent);
                    transform.position = target.transform.position;
                    target.transform.position = beginPos;
                    
                }
                //若是从窗口页面上拖拽下来的， 则丢弃之前的物品
                else if(isNew==true)
                {
                    transform.position = target.transform.position;
                    originParent.GetComponent<Inventory>().panelShow = false;
                    Destroy(target.gameObject);
                }
                transform.SetParent(target.parent.transform);
                transform.localScale = Vector3.one;
                image.raycastTarget = true;
            }
            else if(target.tag=="Ground" && isNew==false)//如果Item被从槽中拖到地面上,直接丢弃
            {
                Destroy(transform.gameObject);
            }
            else
            {
                transform.position = beginPos;
                transform.SetParent(originParent);
                transform.localScale = Vector3.one;
                image.raycastTarget = true;
            }
    }
}

