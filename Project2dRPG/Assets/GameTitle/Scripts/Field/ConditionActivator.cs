using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalActivator : MonoBehaviour
{
    public GameObject Charactor; // 探索するオブジェクト
    public GameObject GameObject; // 機能させたいバックアップオブジェクト

    void Start()
    {
        // 指定したターゲットオブジェクトがシーンに存在するか確認
        if (Charactor == null)
        {
            // ターゲットオブジェクトが存在しない場合
            if (GameObject != null)
            {
                GameObject.SetActive(true); // バックアップオブジェクトをアクティブにする
                Debug.Log("TargetObjectが見つからないため、BackupObjectをアクティブにしました。");
            }
        }
        else
        {
            // ターゲットオブジェクトが存在する場合、バックアップオブジェクトは非アクティブ
            if (GameObject != null)
            {
                GameObject.SetActive(false);
                Debug.Log("TargetObjectが見つかったため、BackupObjectを非アクティブにしました。");
            }
        }
    }
}