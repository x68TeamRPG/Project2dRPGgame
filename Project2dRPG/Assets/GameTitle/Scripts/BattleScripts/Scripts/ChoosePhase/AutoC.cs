using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AutoC : MonoBehaviour
{
    public GameObject button; 
    public GameObject panel;

    private GameObject CurrentButton;

    bool flag;

    void Start()
    {
        flag = false;
    }

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            CurrentButton = EventSystem.current.currentSelectedGameObject;
        }
        else
        {
            CurrentButton = null;
            EventSystem.current.SetSelectedGameObject(button);
        }

        if(panel.activeSelf && flag == false)
        {
            flag = true;
            // ボタンを選択状態にする
            EventSystem.current.SetSelectedGameObject(button);
        }

        // 戻るボタンが選択された状態でそのパネルが非表示になったら
        else if(CurrentButton.transform.parent.gameObject.activeInHierarchy == false)
        {
            flag = false;
        }

        Debug.Log("flag: " + flag);
        Debug.Log("panel.activeSelf?: " + panel.activeSelf);
        Debug.Log("EventSystemObject: " + CurrentButton.name);
    }

}