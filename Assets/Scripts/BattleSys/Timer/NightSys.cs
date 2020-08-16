using System.Collections;
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
            GameObject item = mMontserSys.allDoor[i].gameObject;
            for (int f = 0; f < item.transform.childCount; f++)
            {
                Destroy(item.transform.GetChild(f).gameObject);
            }
            mMontserSys.Reset();
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
