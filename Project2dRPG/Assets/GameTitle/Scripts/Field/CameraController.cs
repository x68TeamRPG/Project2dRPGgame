using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 移動速度とズーム速度を設定
    public float moveSpeed = 10f;
    public float zoomSpeed = 1f;
    public float minZoom = 5f; // 最小ズーム
    public float maxZoom = 50f; // 最大ズーム

    // Update is called once per frame
    void Update()
    {
        // カメラの移動 (W, A, S, Dキー)
        float horizontal = Input.GetAxis("Horizontal"); // A, Dキーで横移動
        float vertical = Input.GetAxis("Vertical"); // W, Sキーで縦移動
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // カメラのズーム (上下矢印キー)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Camera.main.fieldOfView -= zoomSpeed * Time.deltaTime; // ズームイン
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Camera.main.fieldOfView += zoomSpeed * Time.deltaTime; // ズームアウト
        }

        // カメラズーム範囲の制限
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minZoom, maxZoom);
    }
}