using UnityEngine;
using UnityEngine.UI;

public class WazaButton : MonoBehaviour
{
    [SerializeField] private BattleManager battleManager;
    [SerializeField] Button EnemyButton;
    [SerializeField] Waza waza;
    private Button wazaButton;
    private GameObject wazaPanel;

    void Start()
    {
        wazaButton = GetComponent<Button>();
        wazaPanel = transform.parent.gameObject;
        wazaButton.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        battleManager.selectedAction.SetAction("waza", waza, null);
        wazaPanel.SetActive(false);
        EnemyButton.interactable = true;
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
