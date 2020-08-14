using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr 
{
    private static PlayerPropertySys playerPropertySys = new PlayerPropertySys();

    private static PlayerMgr mInstance = new PlayerMgr();
    
    public static PlayerMgr Instance
    {
        get
        {
            return mInstance;
        }
    }
    public PlayerPropertySys Property
    {
        get
        {
            return playerPropertySys;
        }
    }
}
