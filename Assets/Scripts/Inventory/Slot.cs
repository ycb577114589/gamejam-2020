using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slot : MonoBehaviour
{
    public bool haveItem = false;
    private void Update()
    {
        if(gameObject.GetComponentsInChildren<Transform>(true).Length <= 1)
        {
            haveItem = false;
        }
        else
        {
            haveItem = true;
        }
    }

}
