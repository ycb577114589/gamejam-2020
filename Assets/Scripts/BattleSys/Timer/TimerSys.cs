using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSys : MonoBehaviour
{
    public float MonringTime = 10f;
    public float NightTime = 20f;
    private float currentTime = 0f;
    public bool bMorning = true;

    public int currentDay = 1;
    public GameObject morning = null;
    public GameObject night = null;
    // Start is called before the first frame update
    void Start()
    {
        RefreshTime(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime != 0)
        {
            currentTime -= Time.deltaTime;
        }
        if (currentTime <= 0)
        {
            if (bMorning)
            { 
                bMorning = false;
                morning.GetComponent<MorningSys>().MorningOver();
                morning.SetActive(false);
                currentTime = NightTime;
                night.SetActive(true);
            }
            else
            {
                currentDay++;
                bMorning = true;
                night.GetComponent<NightSys>().NightOver();
                currentTime = MonringTime;
                morning.SetActive(true);
                night.SetActive(false);
            }

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
