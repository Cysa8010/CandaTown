using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseMove : MonoBehaviour
{
    NavMeshAgent Nav;
    GameObject Destination;
    float NavDefaultSpeed;//初期移動速度保存用
    [SerializeField] float Spd; //移動速度変更後に使用するSpeed
    [SerializeField] float SensingRange; //感知範囲
    [SerializeField] float SpdChangeRange; //感知後移動速度を変える距離
    float Distance; //エネミーとPlayerの距離
    void Start()
    {
        //エネミーのNavMeshAgentを取得
        Nav = GetComponent<NavMeshAgent>();
        //目的地のオブジェクトを取得
        Destination = GameObject.Find("Player");
        NavDefaultSpeed = Nav.speed;
    }

    void Update()
    {
        //2点間の距離を計測
        Distance = Vector3.Distance(Destination.transform.position, this.transform.position);
        if(Distance <= SensingRange)
        {
            //目的地を設定
            Nav.SetDestination(Destination.transform.position);
            
            if(Distance <= SpdChangeRange)
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
