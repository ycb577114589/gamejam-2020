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

    Vector3 vec = new Vector3(0f, 0f, 0f);
    public Animator anim;
    bool bInit = false;

    public Transform weaponPosRight =null;
    public Transform weaponPosLeft =null;
    public string lastKey = "d";
    void FixedUpdate()
    {
        if ((GameRoot.BattleUIMgrInScene!=null && GameRoot.BattleUIMgrInScene.inventory.bPauseByPanel))
        {
            return;
        }
        GameObject t = GameObject.FindWithTag("DeltaPos");
        Vector3 delta = Vector3.zero;
        Vector3 curenPosition = this.transform.position;
        if (Input.GetKey("d"))
        {
            transform.position = transform.position + new Vector3(1.0f, 0, 0.0f) * moveSpeed;
            if(weapon!=null)
            weapon.rotation = Quaternion.Euler(0, 0, 270);
            if (lastKey != "d")
            {
                delta = t.transform.position - weaponPosRight.position;
                t.transform.Translate(delta);
            }

            anim.SetInteger("Stat", 3);

            lastKey = "d";
        }
        else if (Input.GetKey("s"))
        {
            transform.position = transform.position + new Vector3(0.0f, -1.0f, 0.0f) * moveSpeed;
            if (weapon != null)
                weapon.rotation = Quaternion.Euler(0, 0, 180);
            if (lastKey!="s")
            {
                delta = t.transform.position - weaponPosRight.position;
                t.transform.Translate(delta);
            }

            anim.SetInteger("Stat", 1);
            lastKey = "s";
        }
        else if (Input.GetKey("a"))
        {
            transform.position = transform.position + new Vector3(-1.0f, 0.0f, 0.0f) * moveSpeed;
            //weapon.position = left.position + vec;
            if (weapon != null)
                weapon.rotation = Quaternion.Euler(0, 0, 90);
            if (lastKey != "a")
            {
                delta = t.transform.position - weaponPosRight.position;
                t.transform.Translate(delta);
            }

            anim.SetInteger("Stat", 2);
            lastKey = "a";
        }
        else if (Input.GetKey("w"))
        {
            transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.0f) * moveSpeed;
            if (weapon != null)
                weapon.rotation = Quaternion.Euler(0, 0, 0);
            if (lastKey != "w")
            {
                delta = t.transform.position - weaponPosRight.position;
                t.transform.Translate(delta);
            }

            anim.SetInteger("Stat", 0);
            lastKey = "w";

        }
    }
} 
