using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayerControll : SIUnitController
{/* ! Cation !                ↑MonoBehaviourじゃないよ↑  */
    // Start is called before the first frame update
    void Start()
    {
        // とりあえず変数の初期化
        ResetValue();
    }

    // Update is called once per frame
    void Update()
    {
        ResetValue();

        // ここにキー入力またはAIのアルゴリズム

        // 移動
        if (Input.GetKey(KeyCode.A))
        {
            state_ = SDroneControll.ControllState.MOVE;
            moveValue_ = new Vector3(-1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            state_ = SDroneControll.ControllState.MOVE;
            moveValue_ = new Vector3(+1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            state_ = SDroneControll.ControllState.MOVE;
            moveValue_ = new Vector3(0, 0, 1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            state_ = SDroneControll.ControllState.MOVE;
            moveValue_ = new Vector3(0, 0, -1f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            state_ = SDroneControll.ControllState.MOVE;
            moveValue_ = new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            state_ = SDroneControll.ControllState.MOVE;
            moveValue_ = new Vector3(0, -1, 0);
        }

        // 旋回
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            state_ = SDroneControll.ControllState.TURN;
            turnValue_ = -0.5f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            state_ = SDroneControll.ControllState.TURN;
            turnValue_ = 0.5f;
        }

        // 武器
        if (Input.GetKey(KeyCode.Mouse0))//MouseLeft
        {
            state_ = SDroneControll.ControllState.ACTION1;
        }
        if (Input.GetKey(KeyCode.Mouse1))//MouseLeft
        {
            state_ = SDroneControll.ControllState.ACTION2;
        }
        Print();
    }

    void Print()
    {
        Debug.Log("Player : " + state + " : ");
    }
    
}
