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

    [SerializeField] HeroStatus  player = default;
    [SerializeField] EnemyStatus enemy = default;

    private int turn;

    void Start()
    {
        turn = 0;
        attackButton.AttackSelected += ExecTurn;
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
            yield return new WaitForSeconds(2.0f);
            yield return StartCoroutine(EnemyTurn());
        }
        else if (CompareSpeed() == "enemy")
        {
            yield return StartCoroutine(EnemyTurn());
            yield return new WaitForSeconds(2.0f);
            yield return StartCoroutine(PlayerTurn(skill));
        }
        yield return new WaitForSeconds(1.0f);
        textController.Clean();
        commandController.gameObject.SetActive(true);
    }

    IEnumerator PlayerTurn(string skill="Attack")
    {
        yield return StartCoroutine(textController.Write("プレイヤーのターン"));
        yield return StartCoroutine(PlayerAttack());
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

}

