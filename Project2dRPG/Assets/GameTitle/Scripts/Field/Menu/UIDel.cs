using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDel : MonoBehaviour
{
    public GameObject[] uiElements;

    // Start is called before the first frame update
    private static UIDel instance;

    void Start()
    {

        // 初期状態ではすべてのUI要素を非表示にする
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(false);
        }


    }

    // Update is called once per frame
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
}
