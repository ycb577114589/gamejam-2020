using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMgr 
{
    private static SceneMgr _Instance = new SceneMgr();
    public static SceneMgr Instance
    {
        get
        {
            return _Instance;
        }
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
