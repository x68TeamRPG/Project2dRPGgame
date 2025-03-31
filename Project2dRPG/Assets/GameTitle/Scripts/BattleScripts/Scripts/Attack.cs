using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    [SerializeField] HeroStatus  player = default;
    [SerializeField] EnemyStatus enemy = default;

    [SerializeField] Button EnemyButton;
    [SerializeField] Button TextWindow;
    [SerializeField] Text text;
    [SerializeField] GameObject CommandPanel;

    // Start is called before the first frame update
    void Start()
    {
        EnemyButton.onClick.AddListener(OnClick);
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

    void OnClick()
    {
        StartCoroutine(Battle());
    }

    private void OnButtonClickX()
    {
        Debug.Log("Button clicked by X");
        EnemyButton.interactable = false;
        CommandPanel.SetActive(true);
    }

    IEnumerator Battle()
    {  
        if (0 < enemy.CurrentHP)
        {
            var HP = enemy.CurrentHP;
            var damage = player.Attack - enemy.Deffence;
            float damage1 = (1/damage);
            while (HP - damage < enemy.CurrentHP)
            {
                enemy.CurrentHP -= 1;
                //停止
                yield return new WaitForSeconds(damage1);
            }
            Debug.Log($"敵に{player.Attack - enemy.Deffence}のダメージ");
        }
        else
        {
            Debug.Log($"敵はいない");
        }
    }
}

