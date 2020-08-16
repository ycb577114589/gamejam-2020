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

    public Transform up = null;
    public Transform down = null;
    public Transform left = null;
    public Transform right = null;
    Vector3 vec = new Vector3(0f, 0,55f);
    public Animator anim;
    bool bInit = false;
    void FixedUpdate()
    {
        if ((GameRoot.BattleUIMgrInScene!=null && GameRoot.BattleUIMgrInScene.inventory.bPauseByPanel))
        {
            return;
        }
        if (!bInit)
        {
            //weapon.position = up.position + vec;
            //bInit = true;
        }
        Vector3 curenPosition = this.transform.position;
        if (Input.GetKey("d"))
        {
            transform.position = transform.position + new Vector3(1.0f, 0, 0.0f) * moveSpeed;
            weapon.rotation = Quaternion.Euler(0, 0, 270);
            weapon.position = right.position+ vec;
            anim.SetInteger("Stat", 3);
        }
        else if (Input.GetKey("s"))
        {
            transform.position = transform.position + new Vector3(0.0f, -1.0f, 0.0f) * moveSpeed;
            weapon.position = down.position+ vec;
            weapon.rotation = Quaternion.Euler(0, 0, 180);
            anim.SetInteger("Stat", 1);

        }
        else if (Input.GetKey("a"))
        {
            transform.position = transform.position + new Vector3(-1.0f, 0.0f, 0.0f) * moveSpeed;
            weapon.position = left.position+ vec;
            weapon.rotation = Quaternion.Euler(0, 0, 90);
            anim.SetInteger("Stat", 2);
        }
        else if (Input.GetKey("w"))
        {
            transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.0f) * moveSpeed;
            weapon.position = up.position+ vec;
            weapon.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetInteger("Stat", 0);

        }
    }
} 
