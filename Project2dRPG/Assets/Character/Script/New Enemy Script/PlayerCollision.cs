using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    // インスペクターから指定可能なシーン名
    public string nextSceneName = "GameOverScene";

    // フェードスクリプト（画像のスクリプト）をアサインする
    public MonoBehaviour fadeScript;
    private System.Reflection.MethodInfo methodInfo;

    private void Start()
    {
        // フェード関数（IEnumerator）を取得
        methodInfo = fadeScript.GetType().GetMethod("FadeInAndLoadScene");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (methodInfo != null)
            {
                StartCoroutine((IEnumerator)methodInfo.Invoke(fadeScript, null));
            }
            else
            {
                Debug.LogWarning("FadeInAndLoadScene が見つかりません。");
                // フォールバック：フェードなしでシーン移動
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}