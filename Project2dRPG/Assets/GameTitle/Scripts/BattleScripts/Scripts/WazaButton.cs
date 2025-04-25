using UnityEngine;
using UnityEngine.UI;

public class WazaButton : MonoBehaviour
{
    [SerializeField] Button wazaButton;
    [SerializeField] GameObject WazaPanel;
    [SerializeField] Waza waza = default;

    public event System.Action<Waza> WazaSelected;

    void Start()
    {
        wazaButton.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        WazaPanel.SetActive(false);
        WazaSelected?.Invoke(waza);
    }

    
    void Update()
    {
        if (wazaButton.gameObject == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject)
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
        wazaButton.interactable = false;
        WazaPanel.SetActive(true);
    }
}
