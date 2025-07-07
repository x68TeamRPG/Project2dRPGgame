using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{

    public CommandController commandController;
    public TextController textController;
    public ItemController itemController;
    public DecisionButton[] Buttonlist;
    public BattleCommands battleCommands;
    private EmenyStrategy enemyStrategy;

    [SerializeField] HeroStatus player = default;
    [SerializeField] EnemyStatus enemy = default;

    public SelectedAction selectedAction;
    private int turn;

    void Start()
    {
        enemyStrategy = GetComponent<EmenyStrategy>();
        turn = 0;
        foreach (var Button in Buttonlist)
        {
            Button.Selected += () => ExecTurn();
        }
    }

    public void ExecTurn()
    {
        string skill = selectedAction.skill;
        Waza waza = selectedAction.waza;
        Item item = selectedAction.item;
        Debug.Log($"skill={skill}, waza={(waza != null ? waza.name : "<none>")} item={(item != null ? item.name : "<none>")}");
        Debug.Log("turn: " + turn);
        StartCoroutine(Battle());
        turn++;
    }

    IEnumerator Battle()
    {
        textController.TextWindow.GetComponent<Button>().interactable = true;
        player.UpdateStatus();
        enemy.UpdateStatus();
        string skill = selectedAction.skill;
        Waza waza = selectedAction.waza;
        Item item = selectedAction.item;
        
        if (skill == "escape")
        {
            yield return StartCoroutine(Escape());
            yield break;  // 逃げる場合はここで終了
        }

        if (battleCommands.CompareSpeed(player, enemy) == "player")
        {
            yield return StartCoroutine(PlayerTurn());  // プレイヤーターンが終わるまで待つ
            yield return StartCoroutine(FinishJudge());  // 勝敗判定
            yield return new WaitForSeconds(2.0f);
            yield return StartCoroutine(EnemyTurn());
            yield return StartCoroutine(FinishJudge());
        }
        else if (battleCommands.CompareSpeed(player, enemy) == "enemy")
        {
            yield return StartCoroutine(EnemyTurn());
            yield return StartCoroutine(FinishJudge());
            yield return new WaitForSeconds(2.0f);
            yield return StartCoroutine(PlayerTurn());  // プレイヤーターンが終わるまで待つ
            yield return StartCoroutine(FinishJudge());
        }
        yield return new WaitForSeconds(1.0f);
        textController.Clean();
        yield return StartCoroutine(textController.Write("プレイヤーはどうする？"));
        commandController.gameObject.SetActive(true);
    }

    IEnumerator PlayerTurn()
    {
        string skill = selectedAction.skill;
        Waza waza = selectedAction.waza;
        Item item = selectedAction.item;
        Debug.Log("PlayerTurn, skill=" + skill + ", waza=" + (waza != null ? waza.name : "<none>") + ", item=" + (item != null ? item.name : "<none>"));
        yield return StartCoroutine(textController.Write("プレイヤーのターン"));

        switch (skill)
        {
            case "attack":
                yield return StartCoroutine(battleCommands.Attack(player, enemy, waza));
                break;
            case "item":
                yield return StartCoroutine(battleCommands.UseItem(player, item));
                break;
            case "waza":
                yield return StartCoroutine(battleCommands.UseWaza(player, enemy, waza));
                break;
            default:
                break;
        }
    }

    IEnumerator EnemyTurn()
    {
        Waza waza = enemyStrategy.GetEnemyWaza();
        yield return StartCoroutine(textController.Write("敵のターン"));
        yield return StartCoroutine(battleCommands.Attack(enemy, player, waza));
    }

    private IEnumerator FinishJudge()
    {
        if (player.CurrentHP <= 0)
        {
            //テキストウィンドウ制御クラス「力尽きた」
            yield return StartCoroutine(textController.Write("勇者は力尽きた"));
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameoverScene");//ゲームオーバーシーンに以降
            yield return new WaitForSeconds(1.0f);
        }
        if (enemy.CurrentHP <= 0)
        {
            //テキストウィンドウ制御クラス「敵に勝利」「お金をx,経験値をy,歩数をzを手に入れた」
            //敵の技をもっているかの判定
            yield return StartCoroutine(WinProcess());
            //UnityEngine.SceneManagement.SceneManager.LoadScene("FieldScene");//フィールドシーンに以降
            yield return new WaitForSeconds(1.0f);
        }
    }

    private IEnumerator WinProcess()
    {
        //テキストウィンドウ制御クラス「敵に勝利」「お金をx,経験値をy,歩数をzを手に入れた」
        //敵の技をもっているかの判定
        yield return StartCoroutine(textController.Write("敵に勝利"));
    }

    public IEnumerator Escape()
    {
        yield return StartCoroutine(textController.Write("プレイヤーは逃げ出した！"));
        if (battleCommands.CompareSpeed(player, enemy) == "enemy")
        {
            // 敵が先に行動した場合は逃げられない
            yield return StartCoroutine(textController.Write("逃げることができない！"));
        }
        else
        {
            // 逃げる処理を実行
            yield return StartCoroutine(textController.Write("戦闘から逃げました。"));
            UnityEngine.SceneManagement.SceneManager.LoadScene("FieldScene"); // フィールドシーンに移動
        }
    }

}

