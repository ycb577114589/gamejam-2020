using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class RefreshMonsterOneDay
{
    public int monsterCreateNumber;

    //每一波的刷新间隔
    public float refreshTime = 1.0f;

    //刷新的门
    public List<MonsterSpawner> listMonsterDoorsItem = new List<MonsterSpawner>();

    //每波刷新的怪数
    public List<int> listMonsterType1RefreshNumber = new List<int>();
    public List<int> listMonsterType2RefreshNumber = new List<int>();

    //每波刷新怪的比例
    public List<int> listMonsterType1RefreshRatio = new List<int>();
    public List<int> listMonsterType2RefreshRatio = new List<int>();

}

public class MontserSys : MonoBehaviour
{
    public GameObject Monster1 = null;
    public GameObject Monster2 = null;

    public List<RefreshMonsterOneDay> listRefreshMonsterOneDay = new List<RefreshMonsterOneDay>();
    public List<GameObject> allDoor = new List<GameObject>();
    public RefreshMonsterOneDay mRefreshMonsterToday = new RefreshMonsterOneDay();

    //今天第几天
    public int currentDay = 0;
    //当前等待刷新时间
    public float currentRefreshTime = 0;
    //开第几个门
    private int currentOpenDoorTimer = 0;
    //今天刷了第几波怪
    private int mCurrentMonsterNo = 0;

    public bool bWork = true;

    public void Reset()
    {
        bWork = false;        
    }
    public void BeinNight(int day)
    {
        bWork = true;

        SetTodayNightInfo(day);
    }
    void Start()
    {
        SetTodayNightInfo(1);
        for (int i = 0; i < allDoor.Count; i++)
        {
            allDoor[i].SetActive(false);
        }
        for (int i = 0; i < mRefreshMonsterToday.listMonsterDoorsItem.Count; i++)
        {
            mRefreshMonsterToday.listMonsterDoorsItem[i].gameObject.SetActive(true);
        }
    }
    public void SetTodayNightInfo(int todayNo)
    {
        for (int i = 0; i < allDoor.Count; i++)
        {
            allDoor[i].SetActive(false);
        }
        for (int i = 0; i < mRefreshMonsterToday.listMonsterDoorsItem.Count; i++)
        {
            mRefreshMonsterToday.listMonsterDoorsItem[i].gameObject.SetActive(true);
        }
        if (listRefreshMonsterOneDay.Count < todayNo)
        {
            Debug.LogError("today " + todayNo + " no config !!!");
            return;
        }
        mRefreshMonsterToday.refreshTime = listRefreshMonsterOneDay[todayNo-1].refreshTime;
        mRefreshMonsterToday.monsterCreateNumber = listRefreshMonsterOneDay[todayNo-1].monsterCreateNumber;

        mRefreshMonsterToday.listMonsterDoorsItem = listRefreshMonsterOneDay[todayNo - 1].listMonsterDoorsItem;

        mRefreshMonsterToday.listMonsterType1RefreshNumber = listRefreshMonsterOneDay[todayNo - 1].listMonsterType1RefreshNumber;
        mRefreshMonsterToday.listMonsterType2RefreshNumber = listRefreshMonsterOneDay[todayNo - 1].listMonsterType2RefreshNumber;

        mRefreshMonsterToday.listMonsterType1RefreshRatio = listRefreshMonsterOneDay[todayNo - 1].listMonsterType1RefreshRatio;
        mRefreshMonsterToday.listMonsterType2RefreshRatio = listRefreshMonsterOneDay[todayNo - 1].listMonsterType2RefreshRatio;

        currentRefreshTime = 1;
        currentDay = todayNo;
        currentOpenDoorTimer = 0;
    }
    void Update()
    {
        if (!bWork)
        {
            return;
        }
        currentRefreshTime -= Time.deltaTime;
        if (currentRefreshTime <= 0 && mCurrentMonsterNo < mRefreshMonsterToday.monsterCreateNumber)
        {
            currentRefreshTime = mRefreshMonsterToday.refreshTime;
            mRefreshMonsterToday.listMonsterDoorsItem[currentOpenDoorTimer].CreateMonster(
                Monster1,Monster2, 
                mRefreshMonsterToday.listMonsterType1RefreshRatio[mCurrentMonsterNo],     mRefreshMonsterToday.listMonsterType2RefreshRatio[mCurrentMonsterNo],
                mRefreshMonsterToday.listMonsterType1RefreshNumber[mCurrentMonsterNo],    mRefreshMonsterToday.listMonsterType2RefreshNumber[mCurrentMonsterNo]);
            mCurrentMonsterNo++;
            currentOpenDoorTimer++;
        }
    }
}