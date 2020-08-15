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
    public PlayerPropertySys playerProperty;

    int hp = 0;
    public void SetDrug(int id)
    {
        ID = id;
        switch (id)
        {
            case 0:
                intro += "小药丸 立即回复30HP";
                hp = 30;
                break;
            case 1:
                intro += "药瓶 立即回复40HP";
                hp = 40;
                break;
            case 2:
                intro += "大药箱 立即回复50HP";
                hp = 50;
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
        print(intro);
        print("drug的Use事件");
        playerProperty.ChangeValue(PlayerPropertySys.PropertyValueType.Hp, hp);
    }
}
