using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandBasis : MonoBehaviour
{
    [SerializeField] HeroStatus  player = default;
    [SerializeField] EnemyStatus enemy = default;

    public Button button;
    //使用するMP
    public int UsedMp;
    //使用する歩数
    public int UsedStepCount;
    //敵に与えるダメージ
    public int HpDamage;

    // Start is called before the first frame update
    void Start()
    {
        //ボタン押されたときの関数登録
        button.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void OnClickButton()
    {
        //歩数とMPが0より上
        if (player.CurrentMP >= UsedMp && player.StepCount >= UsedStepCount)
        {
            player.CurrentMP -= UsedMp;
            player.StepCount -= UsedStepCount;
            enemy.CurrentHP -= HpDamage;
            Debug.Log($"敵に{HpDamage}のダメージ");
        }
        //MPが0より下
        if (player.CurrentMP < UsedMp)
        {
            Debug.Log("MPが足りない");
        }
        //歩数が0より下
        if (player.StepCount <　UsedStepCount)
        {
            Debug.Log("歩数が足りない");
        }

    }
}
