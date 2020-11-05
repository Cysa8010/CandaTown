using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EUnitControler
{
    [SerializeField] private int moveTimer; //移動管理用

    void Start()
    {
        // とりあえず変数の初期化
        ResetValue();
    }

    // Update is called once per frame
    void Update()
    {


        // ここにキー入力またはAIのアルゴリズム

        moveTimer++;

        // 移動 moveTimer毎に方向を変更

        if (moveTimer < 180 * 3)
        {
            E_Move(2);
        }
        else if(180 * 3 <= moveTimer && moveTimer < 180 * 6)
        {
            E_Move(1);
        }
        else if(180 * 6 <= moveTimer && moveTimer < 180 * 8)
        {
            E_Move(0);
        }
        else if (180 * 8 <= moveTimer && moveTimer < 180 * 12)
        {
            E_Move(1);
        }
        else if (180 * 12 <= moveTimer && moveTimer < 180 * 19)
        {
            E_Move(2);
        }
        else if (180 * 19 <= moveTimer && moveTimer < 180 * 21)
        {
            E_Move(3);
        }
        else if (180 * 21 <= moveTimer && moveTimer < 180 * 23)
        {
            E_Move(0);
        }
        else if (180 * 23 <= moveTimer && moveTimer < 180 * 25)
        {
            E_Move(3);
        }
        else if (180 * 25 <= moveTimer && moveTimer < 180 * 27)
        {
            E_Move(0);
        }
        else if (180 * 27 <= moveTimer && moveTimer < 180 * 29)
        {
            E_Move(3);
        }
        //if (Input.GetKey(KeyCode.A))
        //{
        //    state_ = SDroneControll.ControllState.MOVE;
        //    moveValue_ = new Vector3(-1f, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    state_ = SDroneControll.ControllState.MOVE;
        //    moveValue_ = new Vector3(+1f, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    state_ = SDroneControll.ControllState.MOVE;
        //    moveValue_ = new Vector3(0, 0, 1f);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    state_ = SDroneControll.ControllState.MOVE;
        //    moveValue_ = new Vector3(0, 0, -1f);
        //}
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    state_ = SDroneControll.ControllState.MOVE;
        //    moveValue_ = new Vector3(0, 1, 0);
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    state_ = SDroneControll.ControllState.MOVE;
        //    moveValue_ = new Vector3(0, -1, 0);
        //}

        //// 旋回
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    state_ = SDroneControll.ControllState.TURN;
        //    turnValue_ = -0.5f;
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    state_ = SDroneControll.ControllState.TURN;
        //    turnValue_ = 0.5f;
        //}

        //// 武器
        //if (Input.GetKey(KeyCode.Mouse0))//MouseLeft
        //{
        //    state_ = SDroneControll.ControllState.ACTION1;
        //}
        //if (Input.GetKey(KeyCode.Mouse1))//MouseLeft
        //{
        //    state_ = SDroneControll.ControllState.ACTION2;
        //}
    }

    private void E_Move(int moveDirection)
    {
        // 上
        if (moveDirection == 0)
        {
            state_ = EnemyControll.EnemyControllState.MOVE;
            moveValue_ = new Vector3(0, 0, -1f);
        }
        // 右
        else if (moveDirection == 1)
        {
            state_ = EnemyControll.EnemyControllState.MOVE;
            moveValue_ = new Vector3(+1f, 0, 0);
        }
        // 下
        else if (moveDirection == 2)
        {
            state_ = EnemyControll.EnemyControllState.MOVE;
            moveValue_ = new Vector3(0, 0, 1f);
        }
        // 左
        else if (moveDirection == 3)
        {
            state_ = EnemyControll.EnemyControllState.MOVE;
            moveValue_ = new Vector3(-1f, 0, 0);
        }

    }
}
