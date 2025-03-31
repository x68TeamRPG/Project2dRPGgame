using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public GameObject uiObject;
    public void Tpggle()
    {
        if (uiObject != null)
        {
            uiObject.SetActive(!uiObject.activeSelf);
        }
    }
}
