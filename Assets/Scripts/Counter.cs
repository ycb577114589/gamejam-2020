using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Counter : MonoBehaviour
{
    Text counter; 
    public TimerSys timerSys;
    void Start()
    {
        counter = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        if(timerSys.isDay==true)
        {
            counter.text = "第" + timerSys.currentDay + "天 " + "距离天黑还有" + (int)timerSys.currentTime + "秒";
        }
        if(timerSys.isDay==false)
        {
            counter.text = "第" + timerSys.currentDay + "天 " + "距离天亮还有" + (int)timerSys.currentTime + "秒";
        }
        
    }
}
