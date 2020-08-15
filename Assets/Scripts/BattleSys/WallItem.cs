using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallItem : MonoBehaviour
{

    private BoxCollider2D collider = null;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    } 
    public void OnCollisionEnter(Collision collision)
    {
        Debug.LogError(collision.gameObject.name);
    }
}
