using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] Button itemButton;
    [SerializeField] GameObject ItemPanel;

    public delegate void OnItemClicked();

    public event OnItemClicked ItemSelected;

    void Start()
    {
        itemButton.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        itemButton.interactable = false;
        ItemSelected?.Invoke();
    }

    
    void Update()
    {
        if (itemButton.gameObject == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject)
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
        itemButton.interactable = false;
        ItemPanel.SetActive(true);
    }
}
