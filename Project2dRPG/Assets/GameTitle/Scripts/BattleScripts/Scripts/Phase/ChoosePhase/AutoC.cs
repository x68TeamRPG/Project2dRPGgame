using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AutoC : MonoBehaviour
{
    public GameObject button; 
    public GameObject panel;

    bool flag;

    void Start()
    {
        flag = false;
    }

    void Update()
    {
        if(panel.activeSelf && flag == false && EventSystem.current.currentSelectedGameObject == null)
        {
            flag = true;
            // ボタンを選択状態にする
            EventSystem.current.SetSelectedGameObject(button);
        }
        
        else if(panel.activeSelf == false)
        {
            flag = false;
        }
    }

}