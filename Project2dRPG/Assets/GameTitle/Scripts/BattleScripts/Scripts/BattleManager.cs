using System.Collections;
using System.Collections.Generic;
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

    IEnumerator Battle()
    {
        if (CompareSpeed() == "player")
        {
            StartCoroutine(PlayerTurn());
            yield return new WaitForSeconds(3.0f);
            StartCoroutine(EnemyTurn());
        }
        else if (CompareSpeed() == "enemy")
        {
            StartCoroutine(EnemyTurn());
            yield return new WaitForSeconds(3.0f);
            StartCoroutine(PlayerTurn());
        }
    }

    IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(1.0f);
        textController.Write("プレイヤーのターン");
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1.0f);
        textController.Write("敵のターン");
        yield return new WaitForSeconds(1.0f);
    }

}

