using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPropertySys  :MonoBehaviour
{
    public enum PropertyValueType
    {
        Hp=1,
        Mp=2,
        Count=3,
    };

    private int[] mPropertyValue = new int[(int)PropertyValueType.Count];
    public int[] mPropertyValueMax = new int [(int)PropertyValueType.Count];

    public void Start()
    {
        for(int i = 0; i < mPropertyValueMax.Length; i++)
        {
            mPropertyValue[i] = mPropertyValueMax[i];
        }
    }

    public void ChangeValue(PropertyValueType type,int changeValue)
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
        Debug.Log(mPropertyValue[(int)type]);
        Debug.Log(mPropertyValueMax[(int)type]);
        switch (type)
        {
            case PropertyValueType.Hp:
                GameRoot.BattleUIMgrInScene.hpSlider.value = mPropertyValue[(int)type] * 1.0f / mPropertyValueMax[(int)type];
                break;
            case PropertyValueType.Mp:
                GameRoot.BattleUIMgrInScene.hpSlider.value = mPropertyValue[(int)type] * 1.0f / mPropertyValueMax[(int)type];
                break;
        }
    }

    public int GetValue(PropertyValueType type )
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
