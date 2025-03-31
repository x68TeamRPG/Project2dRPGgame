//MainMenu.cs MainMenuコンポーネント
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MainMenu : MonoBehaviour
{




    public Canvas canvas; // Canvasをアサイン
    public GameObject[] uiElements; // ButtonUIを格納する配列
    private bool isVisible = false;
    private static MainMenu instance;



    void Start()
    {
        // 初期状態ではすべてのUI要素を非表示にする
        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(false);
        }
    }


    private void Awake()
    {

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
    public void MenuChange()
    {
        isVisible = !isVisible;
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

