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
    // メッセージウィンドウ
    public GameObject messagePanel;
    // コマンドパネル
    public GameObject commandPanel;
    // NovelWriterクラスの初期化
    public NovelWriter novelWriter;

    // Start is called before the first frame update
    void Start()
    {   
        Debug.Log(messagePanel == null ? "messagePanel is null" : "messagePanel is set");
        Debug.Log(commandPanel == null ? "commandPanel is null" : "commandPanel is set");

        //ボタン押されたときの関数登録
        button.onClick.AddListener(OnClickButton);
        novelWriter = new NovelWriter(messagePanel, commandPanel, "", 0);
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

            // CUIで確認
            Debug.Log($"敵に{HpDamage}のダメージ");
            Debug.Log($"MPが{UsedMp}減少");
            Debug.Log($"歩数が{UsedStepCount}減少");
            Debug.Log("Novelwriter :");
            Debug.Log(novelWriter == null);
            Debug.Log("Novelwriter.messagePanel :");
            Debug.Log(novelWriter.messagePanel == null);
            Debug.Log("Novelwriter.commandPanel :");
            Debug.Log(novelWriter.commandPanel == null);
            Debug.Log("Novelwriter.text :");
            Debug.Log(novelWriter.text == null);
            Debug.Log("Novelwriter.key :");
            Debug.Log(novelWriter.key == null);

            // ウィンドウに書き込み
            novelWriter.Write("敵に" + HpDamage.ToString() + "のダメージ");
        }
        //MPが0より下
        if (player.CurrentMP < UsedMp)
        {
            Debug.Log("MPが足りない");
        }
        //歩数が0より下
        if (player.StepCount < UsedStepCount)
        {
            Debug.Log("歩数が足りない");
        }

    }
}
