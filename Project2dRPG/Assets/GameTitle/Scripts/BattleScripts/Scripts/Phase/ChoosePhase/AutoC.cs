using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AutoC : MonoBehaviour
{
    public GameObject button; // Inspectorでボタンを指定します

    void Start()
    {
        // ボタンを選択状態にする
        EventSystem.current.SetSelectedGameObject(button);
        
        // 1秒後にスクリプトを無効にする
        Invoke("DisableScript", 1f);
    }

    void DisableScript()
    {
        this.enabled = false; // このスクリプトを無効にする
    }
}