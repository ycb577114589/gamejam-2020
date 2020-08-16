using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorningSys : MonoBehaviour
{
    public WallMgr mWallMgr = null;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void MorningOver()
    {
        for(int i = 0; i< mWallMgr.wallList.Count; i++)
        {
            WallItemSys item = mWallMgr.wallList[i];
            for(int j = 0; j< item.itemSlot.Count; j++)
            {
                int childCount = item.itemSlot[j].transform.childCount;
                for (int k = 0; k < childCount; k++)
                {
                    Destroy(item.itemSlot[j].transform.GetChild(0).gameObject);
                }
            }

            item.Reset();
        }
        
    }
    public void MorningBegin()
    {

        for (int i = 0; i < mWallMgr.wallList.Count; i++)
        {
            WallItemSys item = mWallMgr.wallList[i];
            item.ReBegin();
        }
    }
}
