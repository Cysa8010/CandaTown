using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleMove : MonoBehaviour
{
    #region

    // Enemy取得用
    // [SerializeField] private GameObject Enemy;

    // 角度
    private Quaternion rotation;

    // 時間
    private float lerpValue = 2.0f;

    // 変更する角度
    [SerializeField] private float Angle = 60.0f;
    private Quaternion rotateAngle;

    // コルーチン2重作用防止
    private bool bIsBusy;
    private float time, progress;

    #endregion


    // Start is called before the first frame update
    private void Start()
    {
        // 最初の回転角初期化
        rotation = transform.rotation;
        rotateAngle = Quaternion.Euler(0.0f, 0.0f, -Angle);

        lerpValue = 2.0f;

        bIsBusy = false;
    }

    // Update is called once per frame
    private void Update()
    {
        // Debug用
        if (Input.GetKeyDown(KeyCode.O))
        {
            // transform.rotation = Quaternion.Euler(0.0f, 0.0f, -Angle);

            if (!bIsBusy)
            {
                StartCoroutine("MoveObstacle");
            }
        }
    }


    /// <summary>
    /// 移動用コルーチン
    /// </summary>
    /// <returns></returns>
    public IEnumerator MoveObstacle()
    {
        // コルーチン2重防止ON
        bIsBusy = true;

        // カウント用の時間変数
        time = 0.0f; 
        // leap用の移動速度保管用
        progress = 0.0f;

        while (progress < 1.0f)
        {
            time += Time.deltaTime;
            if(time > 0.5)
            {
                time += Time.deltaTime;
            }

            progress = time / lerpValue;

            this.transform.rotation = Quaternion.Lerp(rotation, rotateAngle, progress); // 線形補間

            yield return null;
        }
    }

}