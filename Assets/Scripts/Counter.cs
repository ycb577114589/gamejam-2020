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
        counter.text = "第"+timerSys.currentDay+"天 "+"距离天黑/亮还有"+(int)timerSys.currentTime+"秒";
    }
}
