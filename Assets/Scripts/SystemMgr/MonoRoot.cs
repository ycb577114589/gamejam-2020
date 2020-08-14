using System.Collections;
using System.Collections.Generic;
using UnityEngine; 


public class MonoRoot : MonoBehaviour
{
    [SerializeField]
    private GameObject root = null;
    public BattleUIMgr BattleUI;
    void Start()
    {
        GameRoot.SetMonoRoot(this);
        DontDestroyOnLoad(root);//切换场景不销毁clone 
    }

    void Update()
    { 

    }
}

public class GameRoot
{
    private static GameRoot mInstance = new GameRoot();
    public GameRoot Instance
    {
        get
        {
            return mInstance;
        }
    }
    #region 设置UI根节点
    private static MonoRoot MonoRoot = null;
    public static void SetMonoRoot(MonoRoot root)
    {
        MonoRoot = root;
    }
    #endregion

    public static MonoRoot MonoRootInstanceScene
    {
        get
        {
            if(MonoRoot == null)
            {

            }
            return MonoRoot;
        }
    }
    public static BattleUIMgr BattleUIMgrInScene
    {
        get
        {
            if (MonoRoot == null||MonoRoot.BattleUI==null)
            {
                UnityEngine.Debug.LogError("BattleUIMgrInScene is null");
                return null;
            }
            return MonoRoot.BattleUI;
        }
    }
}