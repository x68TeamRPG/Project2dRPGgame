using UnityEngine;
using UnityEngine.UI;

public class WazaButton : MonoBehaviour
{
    private Button wazaButton;
    private GameObject wazaPanel;
    [SerializeField] Waza waza;

    public event System.Action<Waza> WazaSelected;

    void Start()
    {
        wazaButton = GetComponent<Button>();
        wazaPanel = transform.parent.gameObject;
        wazaButton.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        wazaPanel.SetActive(false);
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
        wazaPanel.SetActive(true);
    }
}
