﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallItemSys : MonoBehaviour
{
    public List<GameObject> itemSlot = new List<GameObject>();
    public List<int> itemSlotRatio = new List<int>() { };


    private bool[] bActive;
    private bool bRefreshItem = false;

    private int activeNumber = 0;

    public GameObject thing = null;
    // Start is called before the first frame update
    void Start()
    {
        bActive = new bool[itemSlot.Count];
        for (int i = 0; i < bActive.Length; i++)
        {
            bActive[i] = false;
        }
        for (int i = 0; i < itemSlot.Count; i++)
        {
            itemSlot[i].SetActive(false);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (bRefreshItem)
        {
            Debug.LogError("2");
            System.Random ra = new System.Random();
            int rd = ra.Next(0, 100);
            int cnt = 0;
            int chooseItem = -1;
            for (int i = 0; i < itemSlot.Count; i++)
            {
                cnt += itemSlotRatio[i];
                if (rd <= itemSlotRatio[i] &&  !bActive[i])
                {
                    chooseItem = i;
                    break;
                }
            }

            if (chooseItem == -1)
            {
                for (int i = 0; i < itemSlot.Count; i++)
                {
                    if (!bActive[i])
                    {
                        chooseItem = i;
                        break;
                    }
                }
            }
            if (chooseItem != -1)
            {
                bRefreshItem = false;
                activeNumber++;
                bActive[chooseItem] = true;
                itemSlot[chooseItem].SetActive(true);
                var obj = GameObject.Instantiate(mBox, itemSlot[chooseItem].transform);
                obj.transform.SetParent(itemSlot[chooseItem].transform);

            }
        }
    }


    public bool Over {
        get
        {
            return activeNumber >= itemSlot.Count;
        }
    }
    public bool SetCanRefresh
    {
        set
        {
            bRefreshItem = value;
        }
    } 
    public GameObject SetThing
    {
        set
        {
            thing = value;
        }
    }
    private GameObject mBox = null;
    public GameObject Box
    {
        set
        {
            mBox = value;
        }
    }
}
