﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallItem : MonoBehaviour
{
    public List<GameObject> itemSlot = new List<GameObject>();
    public List<int> itemSlotRatio = new List<int>() { };


    private bool[] bActive;
    private bool bRefreshItem = false;

    private int activeNumber = 0;
    private BoxCollider2D collider;
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
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bRefreshItem)
        {
            System.Random ra = new System.Random();
            var rd = ra.Next(0,100); 
            for(int i =0; i < itemSlot.Count; i++)
            {
                if (rd <= itemSlotRatio[i] && !bActive[i])
                {
                    bRefreshItem = false;
                    activeNumber++;
                    bActive[i] = true;
                    itemSlot[i].SetActive(true);
                    break;
                }
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
    public void OnTriggerEnter(Collider other)
    {
        Debug.LogError(other.name);
    }
}
