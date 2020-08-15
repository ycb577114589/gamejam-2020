using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontserSys : MonoBehaviour
{
    public GameObject Monster = null;
    public List<MonsterItem> listMonsterItem = new List<MonsterItem>();

    public float refreshTime;
    private float currentRefreshTime;
    // Start is called before the first frame update
    void Start()
    {
        currentRefreshTime = refreshTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentRefreshTime -= Time.deltaTime;
        if (currentRefreshTime <= 0)
        {
            for(int i = 0;i<listMonsterItem.Count;i++)
            {
                listMonsterItem[i].CreateMonster(Monster);
            }
            currentRefreshTime = refreshTime;
        }
    }
}
