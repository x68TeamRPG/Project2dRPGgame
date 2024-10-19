using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoButton : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GameObject.Find("CommandPhaseCanvas/Wa/Button").GetComponent<Button>();
        //ボタンが選択された状態になる
        button.Select();
    }
}