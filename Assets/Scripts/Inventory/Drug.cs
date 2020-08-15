using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Drug : MonoBehaviour, IPointerClickHandler
{
    public int ID;
    public string intro="";

    public UnityEvent leftClick;
    private float time;

    public void SetDrug(int id)
    {
        ID = id;
        switch (id)
        {
            case 0:
                intro += "小药丸 立即回复30HP";
                break;
            case 1:
                intro += "药瓶 立即回复40HP";
                break;
            case 2:
                intro += "大药箱 立即回复50HP";
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
            Use();
        }
        time = Time.time;
    }
    public void Use()
    {
        print(intro);
        print("drug的Use事件");
    }
}
