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
   

    // Start is called before the first frame update
    void Start()
    {
        director = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayableDirector>();
        RefreshTime(true);
    }

    // Update is called once per frame
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
