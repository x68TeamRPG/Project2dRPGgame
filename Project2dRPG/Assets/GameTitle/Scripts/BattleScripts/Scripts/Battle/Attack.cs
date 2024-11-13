using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    [SerializeField] HeroStatus  player = default;
    [SerializeField] EnemyStatus enemy = default;

    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        //ボタン押されたときの関数登録
        button.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void OnClickButton()
    {
        enemy.CurrentHP -= player.Attack - enemy.Deffence;
        Debug.Log($"敵に{player.Attack - enemy.Deffence}のダメージ");
    }
}

