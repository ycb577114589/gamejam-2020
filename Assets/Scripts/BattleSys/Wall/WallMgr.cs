using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            System.Random ra = new System.Random();
            int rd = ra.Next(0, 100);
            for (int i = 0; i < wallList.Count; i++)
            {
                if (rd <= wallListRatio[i] && !wallList[i].Over)
                {
                    RandomThing();
                    //wallList[i].SetCanRefresh = true;
                    //wallList[i].SetThing(RandomThing());
                    break;
                }
            }
            currentTime = refreshTime;
        }
    }
    public int RandomBase(List<int> radios)
    {
        System.Random ra = new System.Random();
        var rd = ra.Next(0, 100);
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
        int switchId = RandomBase(baseRadio);
        if (switchId == 0)
        {
            Debug.LogError("food");
        }
        if (switchId == 1)
        {
            Debug.LogError("drug");
        }
        if (switchId == 2)
        {
            Debug.LogError("battery");
        }
        if (switchId == 3)
        {
            Debug.LogError("others");
        }
        return null;
    }
    public List<GameObject> foods = new List<GameObject>();
    public List<GameObject> drug = new List<GameObject>();
    public List<GameObject> battery = new List<GameObject>();
    public List<GameObject> others = new List<GameObject>();

    public List<int> baseRadio = new List<int>();

    public List<int> foodsRatio = new List<int>();
    public List<int> drugRatio = new List<int>();
    public List<int> BatteryRatio = new List<int>();
    public List<int> othersRatio = new List<int>();

}
