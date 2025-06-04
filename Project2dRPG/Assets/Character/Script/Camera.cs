using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 diff; //カメラとプレイヤーの距離
    private GameObject target; //追従するターゲットオブジェクト
    public float followSpeed; //追従するスピード

    void Start()
    {
        target = GameObject.Find("Hero"); //名前がPlayerのオブジェクトを取得してターゲットに指定
        diff = target.transform.position - this.transform.position; //カメラとプレイヤーの初期の距離を指定
    }

    //void LateUpdate()
    //{
    //  transform.position = Vector3.Lerp(this.transform.position, target.transform.position - diff, Time.deltaTime * followSpeed); //線形補間関数によるカメラの移動
    //}
    void LateUpdate()
    {
        // 現在のカメラ位置
        Vector3 currentPos = this.transform.position;

        // ターゲット（プレイヤー）の位置
        Vector3 targetPos = target.transform.position - diff;
        // XとZは今のままにして、Yだけターゲットに追従
        Vector3 newPos = new Vector3(
        currentPos.x,
        Mathf.Lerp(currentPos.y, targetPos.y, Time.deltaTime * followSpeed),
        currentPos.z
        );

        // 位置を更新
        transform.position = newPos;
    }
}