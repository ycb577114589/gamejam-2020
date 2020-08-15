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
                item.itemSlot[j].SetActive(false);
            }
        }
        
    }
}
