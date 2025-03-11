using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSaveUI : MonoBehaviour
{
    public GameObject targetUI;


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
}
