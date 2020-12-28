using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject Target;
    EnemyChaseMove ChaseMove;
    private float sec;
    [SerializeField] float FireInterval;
    void Awake()
    {
        ChaseMove = this.GetComponent<EnemyChaseMove>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Target発見時
        if (ChaseMove.IsDiscovery)
        {
            sec += Time.deltaTime;
            if (sec >= FireInterval)
            {
                sec = 0.0f;
                Shot();
            }
        }
    }
    // 弾発射
    void Shot()
    {
        //TargetとAgentの位置から向きベクトルを作成
        Vector3 dist = (Target.transform.position - this.transform.position).normalized;
        //rayにRayの原点とする座標座標とTargetの方向を格納
        //Ray ray = new Ray(this.transform.position, dist);
        double a = transform.position.y + 0.2;
        Ray ray = new Ray(new Vector3(this.transform.position.x, (float)a, this.transform.position.z), dist);
        RaycastHit rayHit;

        //AgentからTargetへ向けて感知範囲の距離だけRayを飛ばす 結果をrayHitに格納
        Physics.Raycast(ray, out rayHit, ChaseMove.SensingRange);
        //Debug用Ray表示
        Debug.DrawRay(ray.origin, ray.direction * ChaseMove.SensingRange, Color.blue, 1, false);
        if (rayHit.collider.transform.GetInstanceID() == Target.transform.GetInstanceID())
        {
            Debug.Log("Shoot(Enemy)");
            GameObject go = Instantiate(bullet, emitter.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(new Vector3(dist.x * 500, dist.y * 50, dist.z * 500));
            //go.transform.position = Vector3.MoveTowards(go.transform.position,
            //    new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z), 1.5f);
            //そりゃあ更新かけ続けないとダメでしょうよ
        }
    }
    // 撃つ弾
    [SerializeField] private GameObject bullet = null;
    // 発射口
    [SerializeField] private GameObject emitter = null;
}
