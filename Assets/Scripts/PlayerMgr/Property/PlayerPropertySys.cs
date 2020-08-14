using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPropertySys  
{
    
    public enum PropertyValueType
    {
        Hp=1,
        Mp=2,
        Count=3,
    };
    public int[] mPropertyValue = new int[(int)PropertyValueType.Count];
    public int[] mPropertyValueMax = new int [(int)PropertyValueType.Count];
    public void ChangeValue(PropertyValueType type,int changeValue)
    {
        if (type <= PropertyValueType.Count)
        {
            //这里留个奇怪的逻辑， 不清楚他们是否会设置一个hp上限
            if (mPropertyValueMax[(int)type] == 0 || mPropertyValue[(int)type] + changeValue < mPropertyValueMax[(int)type])
            {
                mPropertyValue[(int)type] += changeValue;
            }
        }
        switch (type)
        {
            case PropertyValueType.Hp:
                GameRoot.BattleUIMgrInScene.hpSlider.value = 0.1f;
                break;
            case PropertyValueType.Mp:
                GameRoot.BattleUIMgrInScene.hpSlider.value = 0.2f;
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
