using System;
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

        //[Flags]
        int dire = 0;

        if (Input.GetKey(KeyCode.A))
        {
            state_ |= SDroneControll.ControllState.MOVE;
            dire |= 1;
            moveValue_ += - transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            state_ |= SDroneControll.ControllState.MOVE;
            dire |= 1;
            moveValue_ += transform.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            state_ |= SDroneControll.ControllState.MOVE;
            dire |= 2;
            moveValue_ += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            state_ |= SDroneControll.ControllState.MOVE;
            dire |= 2;
            moveValue_ += - transform.forward;
        }

        if (Input.GetKey(KeyCode.R))
        {
            state_ |= SDroneControll.ControllState.MOVE;
            dire |= 4;
            moveValue_ += transform.up;
        }
        if (Input.GetKey(KeyCode.F))
        {
            state_ |= SDroneControll.ControllState.MOVE;
            dire |= 4;
            moveValue_ += -transform.up;
        }

        if(dire==3||dire==5||dire==6)
        {
            moveValue_ /= 2f;
        }
        if(dire==7)
        {
            moveValue_ /= 3;
        }

        // 旋回
        if (Input.GetKey(KeyCode.Q))
        {
            state_ |= SDroneControll.ControllState.TURN;
            turnValue_ = -0.5f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            state_ |= SDroneControll.ControllState.TURN;
            turnValue_ = 0.5f;
        }

        // 武器
        if (Input.GetKey(KeyCode.Mouse0))//MouseLeft
        {
            state_ |= SDroneControll.ControllState.ACTION1;
        }
        if (Input.GetKey(KeyCode.Mouse1))//MouseLeft
        {
            state_ |= SDroneControll.ControllState.ACTION2;
        }
    }
}
