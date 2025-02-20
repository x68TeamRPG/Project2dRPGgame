using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dontdestoroy : MonoBehaviour
{
    private static Dontdestoroy instance;
    // Start is called before the first frame update
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
