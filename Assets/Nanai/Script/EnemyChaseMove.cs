using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseMove : MonoBehaviour
{
    NavMeshAgent Nav;
    [SerializeField] GameObject Destination; //目的地オブジェクト
    float NavDefaultSpeed;//初期移動速度保存用
    [SerializeField] float Spd; //移動速度変更後に使用するSpeed
    [SerializeField] float SensingRange; //感知範囲
    [SerializeField] float SpdChangeRange; //感知後移動速度を変える距離
    float Distance; //エネミーと目的地オブジェクトの距離
    [SerializeField] float searchAngle; //エネミーの視野(50と入力すると片側50度なので視界は100度になる)
    Animator animator;
    void Start()
    {
        //エネミーのNavMeshAgentを取得
        Nav = GetComponent<NavMeshAgent>();
        //目的地のオブジェクトを取得
        //fix [SerializeField]付けたのでInspectorからGameObjectを指定してください。これ多分重いから。
        //Destination = GameObject.Find("Goal");
        animator = GetComponent<Animator>();
        NavDefaultSpeed = Nav.speed;

        //目的地を初期化
        Nav.SetDestination(this.transform.position);
    }

    void Update()
    {
        //2点間の距離を計測
        Distance = Vector3.Distance(Destination.transform.position, this.transform.position);
        if(Distance <= SensingRange)
        {
            Vector3 dist = Destination.transform.position - this.transform.position;
            float angle = Vector3.Angle(transform.forward, dist);  // 敵から見たプレイヤーの方向
            if (angle <= searchAngle)
            {
                animator.SetBool("Is_Running", true);
                //目的地を設定
                Nav.SetDestination(Destination.transform.position);

                if (Distance <= SpdChangeRange)
                {
                    //移動速度変更
                    Nav.speed = Spd;
                }
                else
                {
                    //移動速度を戻す
                    Nav.speed = NavDefaultSpeed;
                }
            }
        }
    }
}
