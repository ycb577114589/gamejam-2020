using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{   /*
    //存储图片中心点与鼠标点击点的偏移量
    private Vector3 offset;
    //存储当前拖拽图片的RectTransform组件
    private RectTransform rect;
    private Vector3 beginPos;
    void Start()
    {
        rect = this.transform.GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = Vector3.zero;
        rect.position = Input.mousePosition + offset;
        beginPos = rect.position;
    }

    //拖拽过程中触发
    public void OnDrag(PointerEventData eventData)
    {
        rect.position = Input.mousePosition + offset;
    }
    //结束拖拽触发
    public void OnEndDrag(PointerEventData eventData)
    {
        Ray ray = new Ray(rect.position, new Vector3(0,0,-1));
        RaycastHit hit;
        bool isCollided = Physics.Raycast(ray, out hit);
        if(isCollided)
        {
            if (hit.collider.tag == "Slot")
            {
                bool haveItem = hit.collider.gameObject.GetComponent<Slot>().haveItem;
                if (haveItem == false)
                {
                    //放置
                    rect.position = hit.collider.transform.position;
                }
                else
                {
                    //替换
                }
            }
            else
            {
                rect.position = beginPos;
            }
        }
    }*/
    private Vector3 beginPos;
    private Image image;
    void Start()
    {
        beginPos = transform.position;
        image = transform.GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        beginPos = transform.position;
        transform.SetAsLastSibling();
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        ItemPickUp drag = eventData.pointerEnter.GetComponent<ItemPickUp>();
        if (drag != null && drag.transform != transform)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ItemPickUp drag = eventData.pointerEnter.GetComponent<ItemPickUp>();
        if (drag != null && drag.transform != transform)
        {
            Vector3 pos = drag.transform.position;
            drag.transform.position = beginPos;
            transform.position = pos;
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.position = beginPos;
            transform.localScale = Vector3.one;
        }
        image.raycastTarget = true;
    }
}

