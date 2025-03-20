using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{

    public CommandController commandController;
    public TextController textController;
    public AttackButton attackButton;

    private WazaDB wazaDB;
    public ItemController itemController;
    public ItemButton itemButton;

    [SerializeField] HeroStatus  player = default;
    [SerializeField] EnemyStatus enemy = default;

    private int turn;

    void Start()
    {
        wazaDB = new WazaDB();
        itemController = GetComponent<ItemController>();
        turn = 0;
        attackButton.AttackSelected += ExecTurn;
        itemButton.ItemSelected += ExecTurn;
    }
    
    public void ExecTurn()
    {
        Debug.Log("turn: " + turn);
        StartCoroutine(Battle());
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

    IEnumerator PlayerTurn(string skill="Attack")
    {
        yield return StartCoroutine(textController.Write("プレイヤーのターン"));
        //yield return StartCoroutine(PlayerAttack());
        yield return StartCoroutine(PlayerItem());
    }

    IEnumerator EnemyTurn()
    {
        yield return StartCoroutine(textController.Write("敵のターン"));
        yield return StartCoroutine(EnemyAttack());
    }

    IEnumerator PlayerAttack()
    {  
        if (0 < enemy.CurrentHP)
        {
            int HP = enemy.CurrentHP;
            int damage = player.Attack - enemy.Deffence;
            float damage1 = (1/damage);
            while (HP - damage < enemy.CurrentHP)
            {
                enemy.CurrentHP -= 1;
                //停止
                yield return new WaitForSeconds(damage1);
            }
            Debug.Log($"敵に{damage}のダメージ");
            yield return StartCoroutine(textController.Write($"敵に{player.Attack - enemy.Deffence}のダメージ"));
        }
    }
    IEnumerator PlayerItem()
    {
        yield return new WaitForSeconds(1.0f);
        itemController.UseItem("Potion");
    }

    IEnumerator EnemyAttack()
    {
        if (0 < player.CurrentHP)
        {
            int HP = player.CurrentHP;
            int damage = 5;//enemy.Attack - player.Deffence;
            if (damage > 0)
            {
                float damage1 = (1/damage);
                while (HP - damage < player.CurrentHP)
                {
                    player.CurrentHP -= 1;
                    //停止
                    yield return new WaitForSeconds(damage1);
                }
            }
            Debug.Log($"プレイヤーに{damage}のダメージ");
            yield return StartCoroutine(textController.Write($"プレイヤーに{damage}のダメージ"));
        }
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

    private bool WazaChecker(EnemyStatus enemy)
    {
        if (wazaDB.HasWaza(enemy.waza.name))
        {
            return true;
        }
        return false;
    }

    private IEnumerator WinProcess()
    {
        //テキストウィンドウ制御クラス「敵に勝利」「お金をx,経験値をy,歩数をzを手に入れた」
        //敵の技をもっているかの判定
        yield return StartCoroutine(textController.Write("敵に勝利"));
        player.Money += enemy.money;
        player.Exp += enemy.exp;
        player.AddStepCount(enemy.step);
        yield return StartCoroutine(textController.Write("お金を " + enemy.money + " 手に入れた"));
        yield return StartCoroutine(textController.Write("経験値を " + enemy.exp + " 手に入れた"));
        yield return StartCoroutine(textController.Write("歩数を " + enemy.step + " 手に入れた"));

        if (WazaChecker(enemy))
        {
            wazaDB.AddWaza(enemy.waza);
            yield return StartCoroutine(textController.Write("新しく" + enemy.waza.name + "を覚えた"));
        }
    }

}

