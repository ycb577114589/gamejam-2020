using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateMonster(GameObject obj)
    {
        var monster = GameObject.Instantiate(obj,this.transform.position,this.transform.rotation);
        monster.transform.SetParent (this.gameObject.transform);
    }
}
