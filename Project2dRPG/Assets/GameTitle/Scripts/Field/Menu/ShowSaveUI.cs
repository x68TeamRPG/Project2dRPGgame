using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSaveUI : MonoBehaviour
{
    public GameObject targetUI;
    private static ShowSaveUI instance;


    void Start()
    {
        targetUI.SetActive(false);
    }
    private void Awake()
    {
        // シングルトンパターン: オブジェクトが重複して生成されないようにする
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // シーンをまたいでも削除されないように設定
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ToggleUI()
    {
        if (targetUI != null)
            targetUI.SetActive(!targetUI.activeSelf
            );
    }
}
