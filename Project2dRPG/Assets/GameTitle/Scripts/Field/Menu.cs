using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUIVisibility : MonoBehaviour
{
    public Canvas canvas; // Canvasをアサイン
    public GameObject[] uiElements; // ButtonUIを格納する配列
    private bool isVisible = false;

    void Start()
    {
        // 初期状態ではすべてのUI要素を非表示にする
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(false);
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 表示状態を切り替える
            isVisible = !isVisible;

            // Canvasが非アクティブならアクティブにする
            if (!canvas.gameObject.activeSelf)
            {
                canvas.gameObject.SetActive(true);
            }

            // 表示状態に応じてすべてのUI要素の表示を切り替える
            foreach (GameObject uiElement in uiElements)
            {
                uiElement.SetActive(isVisible);
            }
        }
    }
}