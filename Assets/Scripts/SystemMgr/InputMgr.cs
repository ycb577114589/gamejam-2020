using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameRoot.Instance.CanContinueTimer)
        {
            return;
        }
        #region   血量测试例子
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerMgr.Instance.Property.ChangeValue(PlayerPropertySys.PropertyValueType.Hp, -1);
            Debug.LogError("test hp " + PlayerMgr.Instance.Property.GetValue(PlayerPropertySys.PropertyValueType.Hp));
            PlayerMgr.Instance.Property.ChangeValue(PlayerPropertySys.PropertyValueType.Mp, 1);
            Debug.LogError("test mp " + PlayerMgr.Instance.Property.GetValue(PlayerPropertySys.PropertyValueType.Mp));

        }
        #endregion
        #region  切场景例子测试
        //else if (Input.GetKeyDown(KeyCode.F))
        //{
        //    SceneMgr.Instance.LoadScene("Scene1");//跳到1场景

        //} 
        #endregion
    }
}
