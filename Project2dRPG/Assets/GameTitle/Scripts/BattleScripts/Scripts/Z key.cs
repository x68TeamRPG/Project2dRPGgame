using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Zkey : MonoBehaviour
{
    public Button myButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) // Returnキーで決定
        {
            if (EventSystem.current.currentSelectedGameObject == myButton.gameObject)
            {
              myButton.onClick.Invoke(); // ボタンのクリックイベントを手動で発火
            }
        }
    }
}
