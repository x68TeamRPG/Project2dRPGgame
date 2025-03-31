using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    [SerializeField] Button EnemyButton;
    [SerializeField] GameObject CommandPanel;

    public delegate void OnAttackClicked();

    public event OnAttackClicked AttackSelected;

    void Start()
    {
        EnemyButton.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        EnemyButton.interactable = false;
        AttackSelected?.Invoke();
    }

    
    void Update()
    {
        if (EnemyButton.gameObject == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject)
        {
            // ボタンが現在選択されているなら…
            if (Input.GetKeyDown(KeyCode.X))
            {
                OnButtonClickX();
            }
        }
    }
    private void OnButtonClickX()
    {
        Debug.Log("Button clicked by X");
        EnemyButton.interactable = false;
        CommandPanel.SetActive(true);
    }
}
