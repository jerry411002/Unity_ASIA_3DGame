
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent nav;
    private Animator ani;
    private float timer;

    [Header("移動速度"), Range(0, 50)]
    public float speed = 3;
    [Header("停止距離"), Range(0, 50)]
    public float stopDistance = 2.5f;
    [Header("攻擊冷卻時間"), Range(0, 50)]
    private float cd = 2f;

    private void Awake()
    {
        // 取得身上元件<代理器>
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        //尋找其他遊戲物件("物件名稱")變形物件
        player = GameObject.Find("阿明").transform;

        //代理器的速度與停止距離
        nav.speed = speed;
        nav.stoppingDistance = stopDistance;
    }
    private void Update()
    {
        Track();
        Attack();
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        if (nav.remainingDistance <stopDistance )
        {
            //時間 累加 (一楨的時間)
            timer += Time.deltaTime;

            //取得玩家座標
            Vector3 pos = player.position;
            //將玩家座標y軸 指定為 本物件的y軸
            pos.y = transform.position.y;
            //(玩家座標)
            transform.LookAt(pos);
            
            if (timer >= cd)
            {
                ani.SetTrigger("攻擊一技");
                timer = 0;
            }
            if (timer >=cd)
            {
                ani.SetTrigger("攻擊二技");
                    timer = 0;
            }
        }
    }
    /// <summary>
    /// 追蹤
    /// </summary>
    private void Track()
    {
        //代理器.設定目的地(玩家的座標)
        nav.SetDestination(player.position);
        //print("剩餘距離：" + nav.remainingDistance);
        //動畫控制.設定布林值("參數名稱"剩餘的距離>停止距離
        ani.SetBool("跑步",nav.remainingDistance > stopDistance);
    }
}

