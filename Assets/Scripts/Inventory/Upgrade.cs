using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 升级物品
/// </summary>
public class Upgrade : MonoBehaviour
{
    private int ID;
    public string intro="";
    public UnityEvent leftClick;

    private bool hasEquiped;
    private bool buff=false;
    private bool deBuff=false;

    public GameObject Introduction;

    PlayerWeaponSys playerWeaponSys;
    public void SetUpgrade(int id)
    {
        this.ID = id;
        switch (id)
        {
            case 0:
                intro += "光线长度升级 更长光线";
                break;
            case 1:
                intro += "光线宽度升级 更宽范围";
                break;
        }
    }
    private void Start()
    {
        playerWeaponSys = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeaponSys>();
        leftClick.AddListener(new UnityAction(DoubleLeftClick));
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

        GameObject go = GameObject.Instantiate(Introduction, Input.mousePosition, Quaternion.identity, transform);
        go.GetComponentInChildren<Text>().text = intro;
        Destroy(go, 2);
    }
    private void Update()
    {
        if (gameObject.transform.parent == null)
            return;
        if(gameObject.transform.parent.tag=="Slot")
        {//装备上
            if(buff==false)
            {
                if(ID==0)
                {
                    playerWeaponSys.AddLength();
                }
                else if(ID==1)
                {
                    playerWeaponSys.AddWidth();
                }
                buff = true;
                deBuff = false;
            }
        }
        else if(gameObject.transform.parent.tag=="Inventory")
        {

        }
        else
        {//没装备上
            if(deBuff==false)
            {
                if(ID==0)
                {
                    playerWeaponSys.ReduceLength();
                }
                else if(ID==1)
                {
                    playerWeaponSys.ReduceWidth();
                }
                buff = false;
                deBuff = true;
            }
        }
    }

}
