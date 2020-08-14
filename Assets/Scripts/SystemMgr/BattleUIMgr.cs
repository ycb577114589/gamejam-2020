using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIMgr : MonoBehaviour
{
    //工程里本不该存在这个，但是为了速度就这么搞了

    public Slider hpSlider;
    public Slider mpSilder;

    //这个方便直接进入Scene1
    [SerializeField]
    private GameObject gameRoot=null;

    void Start()
    {

        GameObject root = GameObject.FindWithTag("GameRoot");

        //这段快速调试用
        if (root == null)
        {
            root = GameObject.Instantiate(gameRoot);
        }

        MonoRoot GameRoot = root.GetComponent<MonoRoot>();
        GameRoot.BattleUI = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
