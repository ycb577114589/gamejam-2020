﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;

public class WallMgr : MonoBehaviour
{

    public List<WallItemSys> wallList = new List<WallItemSys>();

    public List<int> wallListRatio = new List<int>();

    public float refreshTime = 1;
    private float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = refreshTime;
         
    }

    public void Reset()
    {
                
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameRoot.Instance.CanContinueTimer)
        {
            return;
        }
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            int rd = UnityEngine.Random.Range(0, 100);
            int cnt = 0;
            int chooseItem = -1;
            for (int i = 0; i < wallList.Count; i++)
            {
                cnt += wallListRatio[i]; 
                if (rd <= cnt && !wallList[i].Over)
                {
                    chooseItem = i;
                    break;
                }
            }

            if (chooseItem == -1)
            {
                for (int i = 0; i < wallList.Count; i++)
                {
                    if (!wallList[i].Over)
                    {
                        chooseItem = i;
                        break;
                    }
                }
            }
            if (chooseItem != -1)
            {
                GameObject createObj = RandomThing(); 
                if (createObj != null)
                {
                    InventoryBase inventory =createObj.GetComponent<InventoryBase>();

                    for (int i = 0; i < levelRatio.Count; i++)
                    {
                        mLevelUseRatio[i] = levelRatio[i] + levelDeltaRatio[i] * GameRoot.BattleUIMgrInScene.timerSys.currentDay;
                    }

                    int switchId = RandomBase(levelRatio);
                    if(switchId == 0)
                    {
                        inventory.quality = ItemQuality.common;
                    }

                    else if(switchId == 1)
                    {

                        inventory.quality = ItemQuality.epic;
                    }
                    else
                    {
                        inventory.quality = ItemQuality.rare;
                    }

                    wallList[chooseItem].SetThing = createObj;

                    if (bCurrentChooseBase)
                    {
                        wallList[chooseItem].Box = box[0];
                    }
                    else
                    {
                        wallList[chooseItem].Box = box[1];
                    }
                    wallList[chooseItem].SetCanRefresh = true;
                }
            }
            currentTime = refreshTime;
        }
    }
    public int RandomBase(List<int> radios,bool debug = false)
    {

        int rd = UnityEngine.Random.Range(0, 100);
        //System.Random ra = new System.Random((int)DateTime.Now.ToFileTimeUtc());
        //int rd = ra.Next(0, 100);
        int cnt = 0;
        int switchId = 0; 

        for (int i = 0; i < radios.Count; i++)
        {
            cnt += radios[i];
            
            if (rd <= cnt)
            {
                switchId = i;
                break;
            }
        }
        return switchId;
    }
    public GameObject RandomThing()
    {
        int switchBaseOrSpecial = RandomBase(baseOrSpecalBox);

        var chooseBaseOrSpecial = baseRadio;
        bCurrentChooseBase = true;

        if (switchBaseOrSpecial == 1)
        {
            bCurrentChooseBase = false;
            chooseBaseOrSpecial = specialRadio;
        }
        int switchId = RandomBase(chooseBaseOrSpecial);

        if (switchId == 0)
        {
            int itemId = RandomBase(foodsRatio);
            return foods[itemId];
        }
        if (switchId == 1)
        {
            int itemId = RandomBase(drugRatio);
            return drug[itemId];
        }
        if (switchId == 2)
        {
            int itemId = RandomBase(BatteryRatio);
            return battery[itemId];
        }
        if (bCurrentChooseBase==false)
        {
            if (switchId == 3)
            {
                int itemId = RandomBase(updateRatio);
                return update[itemId];
            }
            if (switchId == 4 && others.Count > 0)
            {
                int itemId = RandomBase(othersRatio,true);
                return others[itemId];
            }
        }
        return null;
    }
    public bool bCurrentChooseBase = true;

    public List<GameObject> box = new List<GameObject>();
    public List<int> baseOrSpecalBox = new List<int>();

    public List<int> baseRadio = new List<int>();
    public List<int> specialRadio = new List<int>();

    public List<GameObject> foods = new List<GameObject>();
    public List<int> foodsRatio = new List<int>();

    public List<GameObject> drug = new List<GameObject>();
    public List<int> drugRatio = new List<int>();

    public List<GameObject> battery = new List<GameObject>();
    public List<int> BatteryRatio = new List<int>();

    public List<GameObject> update = new List<GameObject>();
    public List<int> updateRatio = new List<int>();

    public List<GameObject> others = new List<GameObject>();
    public List<int> othersRatio = new List<int>();

    public List<int> levelRatio = new List<int>();
    public List<int> levelDeltaRatio = new List<int>();

    public List<int> mLevelUseRatio = new List<int>();


}
