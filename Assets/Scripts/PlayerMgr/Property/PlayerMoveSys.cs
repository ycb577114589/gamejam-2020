using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSys : MonoBehaviour
{


    private Rigidbody2D m_Rigidbody2D;
    [SerializeField]
    private float moveSpeed = 5.0f;
    public Transform weapon = null;

    void Start()
    {

        m_Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

    }
    Vector3 moveTowardPosition = Vector3.zero;
    Vector3 moveDirection = Vector3.zero;

    void FixedUpdate()
    {
        if (!GameRoot.Instance.CanContinueTimer)
        {
            return;
        }

        Vector3 curenPosition = this.transform.position;
        if (Input.GetKey("d"))
        {
            transform.position = transform.position + new Vector3(1.0f, 0, 0.0f) * moveSpeed;
            weapon.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (Input.GetKey("s"))
        {
            transform.position = transform.position + new Vector3(0.0f, -1.0f, 0.0f) * moveSpeed;
            weapon.rotation = Quaternion.Euler(0, 0, 180);

        }
        else if (Input.GetKey("a"))
        {
            transform.position = transform.position + new Vector3(-1.0f, 0.0f, 0.0f) * moveSpeed;
            weapon.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetKey("w"))
        {
            transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.0f) * moveSpeed;
            weapon.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
} 
