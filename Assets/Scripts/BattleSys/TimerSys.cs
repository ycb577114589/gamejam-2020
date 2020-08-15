using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSys : MonoBehaviour
{
    public float MonringTime = 10f;
    public float NightTime = 20f;
    private float currentTime = 0f;
    public bool bMorning = true;
    // Start is called before the first frame update
    void Start()
    {
        RefreshTime(true);
    }

    // Update is called once per frame
    void Update()
    {
        while(currentTime != 0)
        {
            currentTime -= Time.deltaTime;
        }
        if (currentTime <= 0)
        {

        }
    }
    public void RefreshTime (bool bMorning)
    {
        if (bMorning)
        {
            currentTime = MonringTime;
        }
        else
        {
            currentTime = NightTime;
        }
    }
}
