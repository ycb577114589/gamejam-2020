using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Root : MonoBehaviour
{
    public GameObject GameRoot;
    void Start()
    {
        DontDestroyOnLoad(GameRoot);//切换场景不销毁clone 
    }

    void Update()
    {
        SceneManager.LoadScene("Scene1");//跳到1场景
    }
}
