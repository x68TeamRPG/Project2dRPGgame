using UnityEngine;
using UnityEngine.UI;

public class DecisionButton : MonoBehaviour
{
    [SerializeField] Button EnemyButton;
    [SerializeField] GameObject CommandPanel;
    public delegate void OnClicked();
    public event OnClicked Selected;

    void Start()
    {
        EnemyButton = GetComponent<Button>();
        EnemyButton.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        Debug.Log("DecisionButton clicked");
        EnemyButton.interactable = false;
        Selected?.Invoke();
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
