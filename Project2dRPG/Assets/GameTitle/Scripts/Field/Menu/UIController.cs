using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject uiElement; // 表示/非表示にするUI

    private bool isUIActive = false;

   
    void Update()
    {
        // マウスの左クリックでUIを消す
        if (isUIActive && Input.GetMouseButtonDown(0))
        {
            HideUI();
        }
    }

    public void ShowUI()
    {
        if (uiElement != null)
        {
            uiElement.SetActive(true);
            isUIActive = true;
        }
    }

    private void HideUI()
    {
        if (uiElement != null)
        {
            uiElement.SetActive(false);
            isUIActive = false;
        }
    }
}