using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMgr 
{
    SceneMgr _Instance = new SceneMgr();
    public SceneMgr Instance
    {
        get
        {
            return _Instance;
        }
    }
    public void LoadScene(string sceneName)
    {

    }
}
