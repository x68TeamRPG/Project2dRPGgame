using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{

    public CommandController commandController;
    public TextController textController;
    public ItemController itemController;
    public AttackButton attackButton;
    public ItemButton itemButton;
    public WazaButton wazaButton;
    public BattleCommands battleCommands;

    [SerializeField] HeroStatus  player = default;
    [SerializeField] EnemyStatus enemy = default;

    private int turn;

    void Start()
    {
        itemController = GetComponent<ItemController>();
        turn = 0;
        attackButton.AttackSelected += () =>ExecTurn("attack");
        itemButton.ItemSelected += () => ExecTurn("item");
        wazaButton.WazaSelected += (selectedWaza) => ExecTurn("waza", selectedWaza);
    }
    
    public void ExecTurn(string skill, Waza waza = null)
    {
        Debug.Log($"skill={skill}, waza={(waza!=null? waza.name:"<none>")}");
        Debug.Log("turn: " + turn);
        StartCoroutine(Battle(skill));
        turn++;
    }

    public string CompareSpeed()
    {
        if (player.Speed >= enemy.Speed)
        {
            return "player";
        }
        else
        {
            return "enemy";
        }
    }

    IEnumerator Battle(string skill="attack")
    {
        textController.TextWindow.GetComponent<Button>().interactable = true;
        if (CompareSpeed() == "player")
        {
            yield return StartCoroutine(PlayerTurn(skill));  // プレイヤーターンが終わるまで待つ
            yield return StartCoroutine(FinishJudge());  // 勝敗判定
            yield return new WaitForSeconds(2.0f);
            yield return StartCoroutine(EnemyTurn());
            yield return StartCoroutine(FinishJudge());
        }
        else if (CompareSpeed() == "enemy")
        {
            yield return StartCoroutine(EnemyTurn());
            yield return StartCoroutine(FinishJudge());
            yield return new WaitForSeconds(2.0f);
            yield return StartCoroutine(PlayerTurn(skill));
            yield return StartCoroutine(FinishJudge());
        }
        yield return new WaitForSeconds(1.0f);
        textController.Clean();
        yield return StartCoroutine(textController.Write("プレイヤーはどうする？"));
        commandController.gameObject.SetActive(true);
    }

    IEnumerator PlayerTurn(string skill="Attack", Waza waza = null)
    {
        yield return StartCoroutine(textController.Write("プレイヤーのターン"));
        switch (skill)
        {
            case "attack":
                yield return StartCoroutine(battleCommands.Attack(player, enemy));
                break;
            case "item":
                yield return StartCoroutine(battleCommands.UseItem(player));
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
        yield return StartCoroutine(textController.Write("敵のターン"));
        yield return StartCoroutine(battleCommands.Attack(enemy, player));
    }

    private IEnumerator FinishJudge()
    {
        if(player.CurrentHP <= 0)
        {
            //テキストウィンドウ制御クラス「力尽きた」
            yield return StartCoroutine(textController.Write("勇者は力尽きた"));
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameoverScene");//ゲームオーバーシーンに以降
            yield return new WaitForSeconds(1.0f);
        }
        if(enemy.CurrentHP <= 0)
        {
            //テキストウィンドウ制御クラス「敵に勝利」「お金をx,経験値をy,歩数をzを手に入れた」
            //敵の技をもっているかの判定
            yield return StartCoroutine(WinProcess());
            UnityEngine.SceneManagement.SceneManager.LoadScene("FieldScene");//フィールドシーンに以降
            yield return new WaitForSeconds(1.0f);
        }
    }

    private IEnumerator WinProcess()
    {
        //テキストウィンドウ制御クラス「敵に勝利」「お金をx,経験値をy,歩数をzを手に入れた」
        //敵の技をもっているかの判定
        yield return StartCoroutine(textController.Write("敵に勝利"));
    }

}

