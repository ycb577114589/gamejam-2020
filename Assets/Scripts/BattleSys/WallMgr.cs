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
            var rd = ra.Next(0, 100);
            for (int i = 0; i < wallList.Count; i++)
            {
                if (rd <= wallListRatio[i] && !wallList[i].Over)
                {
                    wallList[i].SetCanRefresh = true;
                    break;
                }
            }
            currentTime = refreshTime;
        }
    }
}
