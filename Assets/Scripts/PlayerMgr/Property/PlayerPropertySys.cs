using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPropertySys  :MonoBehaviour
{
    public enum PropertyValueType
    {
        Hp=1,
        Mp=2,
        Count=3,
    };

    bool hasDead = false;
    public GameObject deadPanel;
    public Text deadMessage;
    public TimerSys timerSys;

    private float[] mPropertyValue = new float[(int)PropertyValueType.Count];
    public float[] mPropertyValueMax = new float[(int)PropertyValueType.Count];

    public void Start()
    {
        for(int i = 0; i < mPropertyValueMax.Length; i++)
        {
            mPropertyValue[i] = mPropertyValueMax[i];
        }
    }

    public void ChangeValue(PropertyValueType type,float changeValue)
    {
        if (type <= PropertyValueType.Count)
        {
            if ( mPropertyValue[(int)type] + changeValue < mPropertyValueMax[(int)type] && mPropertyValue[(int)type] + changeValue >= 0 )
            {
                mPropertyValue[(int)type] += changeValue;
            }
            else if (mPropertyValue[(int)type] + changeValue >= mPropertyValueMax[(int)type] )
            {
                mPropertyValue[(int)type] = mPropertyValueMax[(int)type];
            }
            else if (mPropertyValue[(int)type] + changeValue <= 0)
            {
                mPropertyValue[(int)type] = 0;
            }
        }
        float value = ( mPropertyValue[(int)type] * 1.0f) / mPropertyValueMax[(int)type]; ;
        switch (type)
        {
            case PropertyValueType.Hp:
                GameRoot.BattleUIMgrInScene.hpSlider.value = mPropertyValue[(int)type] * 1.0f / mPropertyValueMax[(int)type];
                break;
            case PropertyValueType.Mp:
                GameRoot.BattleUIMgrInScene.mpSilder.value = mPropertyValue[(int)type] * 1.0f / mPropertyValueMax[(int)type];
                break;
        }
    }
    public float lastAddTime = 0f;
    public float currentTime = 0f;
    public float hpRiseNumber = 0f;
    public float maxTime = 0f;
    public float deltaAddHp = 0f;

    //只给血条用
    public void ChangeValue(PropertyValueType type, int changeValue,float deltaTime)
    {
        if (type <= PropertyValueType.Count)
        {
            hpRiseNumber = hpRiseNumber + changeValue;
            currentTime = 0f;
            lastAddTime = 0f;
            maxTime = deltaTime;
            deltaAddHp = hpRiseNumber / deltaTime;
        } 
    }
    public void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime - lastAddTime > 1)
        {
            lastAddTime += 1;
            ChangeValue(PropertyValueType.Hp, deltaAddHp);
            hpRiseNumber -= deltaAddHp;
        }
        if (maxTime <= currentTime)
        {
            lastAddTime = 0f; currentTime = 0f; hpRiseNumber = 0f; maxTime = 0f; deltaAddHp = 0f;
        }

        GameRoot.BattleUIMgrInScene.hpSlider.value = mPropertyValue[(int)PropertyValueType.Hp] * 1.0f / mPropertyValueMax[(int)PropertyValueType.Hp];
        GameRoot.BattleUIMgrInScene.mpSilder.value = mPropertyValue[(int)PropertyValueType.Hp] * 1.0f / mPropertyValueMax[(int)PropertyValueType.Hp];
        if (hasDead == false)
        {
            if (GameRoot.BattleUIMgrInScene.hpSlider.value <= 0)
            {
                
                deadPanel.SetActive(true);
                deadMessage.text = "你坚持了" + timerSys.currentDay + "天";
                hasDead = true;
            }
        }

    }

    public float GetValue(PropertyValueType type )
    { 
        if( type <= PropertyValueType.Count)
        {
            return mPropertyValue[(int)type];
        }
        return 0;
    }
    public void ChangeMaxValue(PropertyValueType type, int changeValue)
    {

        if (type <= PropertyValueType.Count)
        {
            mPropertyValueMax[(int)type] = changeValue;
        }
    }
}
