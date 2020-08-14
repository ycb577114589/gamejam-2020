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
        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneMgr.Instance.LoadScene("Scene1");//跳到1场景
            Debug.LogError("w");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {

            Debug.LogError("a");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {

            Debug.LogError("s");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.LogError("d");
        }
    }
}
