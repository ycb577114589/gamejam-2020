using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
public class TimerSys : MonoBehaviour
{
    public float MonringTime = 10f;
    public float NightTime = 20f;
    private float currentTime = 0f;
    public bool bMorning = true;

    public int currentDay = 1;
    public GameObject morning = null;
    public GameObject night = null;

    //增加的三个物体，分别是播放组件，白天到黑夜的切换动画，黑夜到白天的切换动画
    public PlayableDirector director;
    public PlayableAsset dayToNight;
    public PlayableAsset nightToDay;

    public int maxDay = 3;
    void Start()
    {
        director = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayableDirector>();
        RefreshTime(true);
    }
    
    void Update()
    {

        if (GameRoot.BattleUIMgrInScene.inventory.bPauseByPanel)
        {
            return;
        }

        if (currentTime != 0)
        {
            currentTime -= Time.deltaTime;
        }
        if (currentTime <= 0)
        {
            if (bMorning)
            {

                director.playableAsset = dayToNight;//白天到黑夜切换
                director.Play();

                bMorning = false;
                morning.GetComponent<MorningSys>().MorningOver();
                morning.SetActive(false);
                currentTime = NightTime;
                night.SetActive(true);
                night.GetComponent<NightSys>().NightBegin(currentDay);

            }
            else
            {
                director.playableAsset = nightToDay;//黑夜到白天切换
                director.Play();

                currentDay++;
                bMorning = true;
                night.GetComponent<NightSys>().NightOver();

                currentTime = MonringTime;
                morning.SetActive(true);
                night.SetActive(false);
                morning.GetComponent<MorningSys>().MorningBegin();
            }
            if (currentDay > maxDay)
            {
                Debug.LogError("success");
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
