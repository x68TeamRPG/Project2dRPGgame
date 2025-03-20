using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/// <summary>
/// Button の GameObject にアタッチして使う
/// </summary>
[RequireComponent(typeof(Button))]
public class KeyAssigment : MonoBehaviour

{
    /// <summary>このキーを押すとボタンが反応する</summary>
    [SerializeField] KeyCode _key = default;
    Button _button = default;

    void Start()
    {
        _button = GetComponent<Button>();
    }

    void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            // クリックは離した時に成立するが、ボタンからの場合は押した時点で成立させる
            _button.onClick.Invoke();
            // ボタンを押した時の見た目の変化を起こす
            ExecuteEvents.Execute(_button.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
        }
        else if (Input.GetKeyUp(_key))
        {
            ExecuteEvents.Execute(_button.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
        }
    }
}
