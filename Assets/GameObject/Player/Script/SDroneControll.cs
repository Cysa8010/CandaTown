using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ドローン本体制御
 * ドローンのプロパティ
 * ドローンの操作
*/

public class SDroneControll : MonoBehaviour
{
    /* 操作
     * FBLR      - AddForce
     * Up-Down   - AddForce
     * TurningLR - Transform
     * TriggerWeapon - CreateBullet
     * SwitchWeapon  - ChangeSelector
    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Translate(new Vector3(-1f, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            Translate(new Vector3(1f, 0, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            Translate(new Vector3(0, 0, 1f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            Translate(new Vector3(0, 0, -1f));
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            Translate(new Vector3(0, 1, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Translate(new Vector3(0, -1, 0));
        }
    }

    // ドローンを操作する関数
    // FBLR
    void Translate(Vector3 vec)
    {
        transform.GetComponent<Rigidbody>().AddForce(vec);
    }
    // 上昇・下降(あれ、いらなくね?)
    void TranslateUD(Vector3 vec)
    {

    }
    // 旋回(回転ともいう)
    void Turn(Vector3 vec)
    {

    }

    /* -- プロパティ -- */
    int hp;
    int atk;
    
}
