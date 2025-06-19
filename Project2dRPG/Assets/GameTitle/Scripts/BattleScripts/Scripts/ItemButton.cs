using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    private Button itemButton;
    [SerializeField] GameObject itemPanel;
    [SerializeField] Item item;

    public event System.Action<Item> ItemSelected;

    void Start()
    {
        itemButton = GetComponent<Button>();
        itemPanel = transform.parent.gameObject;
        itemButton.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        ItemSelected?.Invoke(item);
        itemPanel.SetActive(false);
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
        itemPanel.SetActive(true);
    }
}
