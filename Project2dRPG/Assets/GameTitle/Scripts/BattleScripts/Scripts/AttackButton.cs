using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    [SerializeField] BattleManager battleManager;
    [SerializeField] Button EnemyButton;
    [SerializeField] GameObject CommandPanel;
    [SerializeField] Waza waza;
    private Button attackButton;

    void Start()
    {
        attackButton = GetComponent<Button>();
        attackButton.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        battleManager.selectedAction.SetAction("attack", waza, null);
        CommandPanel.SetActive(false);
        EnemyButton.interactable = true;
    }
}
