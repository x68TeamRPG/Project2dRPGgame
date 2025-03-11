using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSaveUI : MonoBehaviour
{
    public GameObject targetUI;

    [SerializeField] private GameObject uiElement;

    private bool isUIActive = false;

    void Start()
    {
        targetUI.SetActive(false);
    }

    public void ToggleUI()
    {
        if (targetUI != null)
            targetUI.SetActive(!targetUI.activeSelf
            );
    }
    public void HideUI()
    {
        if (uiElement != null)
        {
            uiElement.SetActive(false);
            isUIActive = false;
        }
    }
}
