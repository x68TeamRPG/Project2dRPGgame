using UnityEngine;
using UnityEngine.UI;

public class EscapeButton : MonoBehaviour
{
    [SerializeField] BattleManager battleManager;
    [SerializeField] GameObject CommandPanel;
    private Button escapeButton;

    void Start()
    {
        escapeButton = GetComponent<Button>();
        escapeButton.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        battleManager.selectedAction.SetAction("escape", null, null);
        CommandPanel.SetActive(false);
    }
}
