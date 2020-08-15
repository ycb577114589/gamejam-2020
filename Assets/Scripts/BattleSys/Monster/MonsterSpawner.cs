using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private GameObject monsterType1 = null;
    private GameObject monsterType2 = null;

    private bool bStart = false;
    private int RadioType1 = 0;
    private int RadioType2 = 0;

    private int mType1Number = 0;
    private int mType2Number = 0;


    public float refreshTimer = 3f;
    private float currentTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        currentTimer = refreshTimer;
    }

    public void CreateMonster(GameObject obj1, GameObject obj2, int radio1, int radio2, int type1Numeber, int type2Number)
    {
        monsterType1 = obj1;
        monsterType2 = obj2;
        RadioType1 = radio1;
        RadioType2 = radio2;
        mType1Number = type1Numeber;
        mType2Number = type2Number;
        bStart = true;
    }
    private void Update()
    {
        currentTimer -= Time.deltaTime;
        if (bStart && currentTimer<=0&&(mType1Number > 0 || mType2Number > 0))
        {
            System.Random ra = new System.Random();
            int rd = ra.Next(0, 100);
            if ((rd <= RadioType1 && mType1Number > 0) || mType2Number <= 0)
            {
                var monster = GameObject.Instantiate(monsterType1, this.transform.position, this.transform.rotation);
                monster.transform.SetParent(this.gameObject.transform);
                mType1Number--;
            }
            else if (mType2Number > 0)
            {
                var monster = GameObject.Instantiate(monsterType2, this.transform.position, this.transform.rotation);
                monster.transform.SetParent(this.gameObject.transform);
                mType2Number--;
            }
            currentTimer = refreshTimer;
        }
    }
}

