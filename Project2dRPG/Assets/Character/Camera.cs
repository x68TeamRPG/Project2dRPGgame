using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalCameraMove : MonoBehaviour
{
    public float speed = 5f; // 上下移動の速度
    public float minY = 1f; // 最小Y位置
    public float maxY = 5f; // 最大Y位置

    private Vector3 startPosition; // 初期位置（X,Z固定用）

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // 入力取得（W/Sキーや↑↓キーなど）
        float input = Input.GetAxis("Vertical"); // 上下: W/S や ↑↓

        // 現在のYに加算して新しいY位置を計算
        float newY = transform.position.y + input * speed * Time.deltaTime;

        // 制限範囲にクランプ
        newY = Mathf.Clamp(newY, minY, maxY);

        // カメラ位置を更新（X,Zは固定、Yのみ変更）
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}