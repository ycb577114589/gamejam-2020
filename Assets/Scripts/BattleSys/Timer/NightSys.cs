﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightSys : MonoBehaviour
{

    public MontserSys mMontserSys = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NightOver()
    {
        for (int i = 0; i < mMontserSys.allDoor.Count; i++)
        {
            int count = mMontserSys.mRefreshMonsterToday.listMonsterDoorsItem.Count;
            for (int j = 0; j < count; j++)
            {
                GameObject item = mMontserSys.mRefreshMonsterToday.listMonsterDoorsItem[j].gameObject;

                for (int f = 0; f < item.transform.childCount; f++)
                {
                    Destroy(item.transform.GetChild(0).gameObject);
                }
                mMontserSys.Reset();
            }
            //int childCount = transform.childCount;
            //for (int j = 0; j < childCount; j++)
            //{
            //    Destroy(mMontserSys.mRefreshMonsterToday.listMonsterDoorsItem[j].GetChild(0).gameObject);
            //}
        }
    }
    public void NightBegin()
    {
        mMontserSys.BeinNight(); 
    }
}
