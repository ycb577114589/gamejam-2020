using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGame : MonoBehaviour
{
    public GameObject game;
    public GameObject entrance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Beign()
    {
        game.SetActive(true);
        entrance.SetActive(false);
    }
}
