using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterItem : MonoBehaviour
{
    public int Damage = 0;
    public int MaxHp = 0;
    private int currentHp = 0;
    public Slider hp = null;
    private PlayerPropertySys playerProperty = null;
    private PlayerWeaponSys playerWeapon = null; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            currentHp -= playerWeapon.Damage;
            hp.value = currentHp * 1.0f / MaxHp;
            if (currentHp <= 0)
                this.gameObject.SetActive(false);
        } 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            System.Random ra = new System.Random();
            int rd = ra.Next(0,GameRoot.BattleUIMgrInScene.AirWall.Count);

            dir = GameRoot.BattleUIMgrInScene.AirWall[rd].transform.position - collision.transform.position;//给游戏物体一个到随机点的方向，这个方向就是它接下来的运动方向。
        } 
    }

    public float speed = 50;
    public Vector3 dir;//this.gameobject的运动方向
    public int index;//记录随机点
    private float time;//定时器
    public bool isWalk;//状态判断
    private Animator Anim;
    // Start is called before the first frame update

    public GameObject player = null;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        currentHp = MaxHp;
        //写个很挫的代码.
        var temp = GameObject.FindWithTag("Player");
        if (temp != null)
        {
            playerProperty = temp.GetComponent<PlayerPropertySys>();
            playerWeapon = temp.GetComponent<PlayerWeaponSys>();
        }

        dir = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);//给游戏物体一个初始方向，让它去撞击边界触发器
        //Anim = GetComponent<Animator>();
        //Anim.Play("run");
        time = 0;
        isWalk = true;
    }
    public float attackDistance = 10000;
    public float attackRefreshTime = 1f;
    private float currentAttackTime = 0f;
    void FixedUpdate()
    {
        time += Time.deltaTime;//定时
        currentAttackTime -= Time.deltaTime;
        int dis =(int) (transform.position - player.transform.position).sqrMagnitude;
        if (currentAttackTime > 0)
        {
            return;
        }
        if(dis<= attackDistance&&currentAttackTime<=0)
        {
            currentAttackTime = attackRefreshTime;
            if (playerProperty != null)
                playerProperty.ChangeValue(PlayerPropertySys.PropertyValueType.Hp, -Damage);
            return;
        }
        if (dir.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        if (isWalk)
        {
            //运动: anim.play("run")
            transform.localPosition += dir.normalized * speed * Time.deltaTime;
        }
        else
        {
            //停下来吃东西的状态
            //Anim.Play("eat");
        }
    }
    void ChangeState()
    {
        int value = Random.Range(0, 2);
        if (value == 0) //停下来
        {
            isWalk = false;//停止
        }
        else //继续走
        {
            if (!isWalk)//如果本来是停下来的鸡，现在变为走动，那就转一下方向
            {
                dir = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
            }
            isWalk = true;//运动
        }
        time = 0;//定时器清零
    } 
}
