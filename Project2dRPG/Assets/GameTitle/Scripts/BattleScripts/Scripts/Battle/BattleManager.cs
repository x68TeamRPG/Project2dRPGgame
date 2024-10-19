using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
  [SerializeField] character player = default;
  [SerializeField] character enemy = default;

  public Button AttackButton;
    enum Phase
    {
        Start,
        Command,
        Execute,
        Result,
        End,
    }
    Phase phase;

    // メッセージウィンドウのインスタンス
    public NobelWriter messageWindow = new NobelWriter(key: 0);

    // 敵ステータスを含むクラスのインスタンス

    // プレイヤーステータスを含むクラスのインスタンス

    // 技の選択ウィンドウのインスタンス

    IEnumerator Battle()
    {
        while (true)
        {
            yield return null;
            Debug.Log(phase);
            switch(phase)
            {
                case Phase.Start:
                    StartPhase();
                case Phase.Command:
                    CommandPhase();
                    break;
                case Phase.Execute:
                    ExecutePhase(player, enemy);

                    player.selectCommand.Execute(player,player.target);
                    enemy.selectCommand.Execute(enemy,enemy.target);
                //どっちか死ぬまで
                    if (player.hp <= 0 || enemy.hp <= 0)
                    {
                        phase = Phase.Result;
                    }
                    else
                    {
                        phase = Phase.Command;
                    }
                    break;
                case Phase.Result:
                    phase = Phase.End;
                    break;
                case Phase.End:
                    break;
            }
        }
    }

    protected void StartPhase()
    {
        if (phase != Phase.Start)
        {
            Debug.LogError("StartPhaseを呼び出すタイミングがおかしい");
            return;
        }

        messageWindow.SetMessagePanelActive(true);
        return;
    }

    protected void CommandPhase()
    {
        if (phase != Phase.Command)
        {
            Debug.LogError("CommandPhaseを呼び出すタイミングがおかしい");
            return;
        }

        return;
    }

    protected void ExecutePhase(character player, character enemy)
    {
        if (phase != Phase.Execute)
        {
            Debug.LogError("ExecutePhaseを呼び出すタイミングがおかしい");
            return;
        }

        // コマンド選択による処理
        player.selectCommand.Execute(player,player.target);
        enemy.selectCommand.Execute(enemy,enemy.target);

        // 各キャラクタの残りHPを表示
        Debug.Log($"{player.name}の残りHP:{player.hp}");
        Debug.Log($"{enemy.name}の残りHP:{enemy.hp}");

        

        return;
    }

    protected void ResultPhase()
    {
        if (phase != Phase.Result)
        {
            Debug.LogError("ResultPhaseを呼び出すタイミングがおかしい");
            return;
        }

        return;
    }

    protected void EndPhase()
    {
        if (phase != Phase.End)
        {
            Debug.LogError("EndPhaseを呼び出すタイミングがおかしい");
            return;
        }

        return;
    }

    protected void BacktoField()
    {
        // バトル終了時にフィールドに戻る処理
    }

    protected void GotoGameOver()
    {
        // プレイヤーが負けた時の処理

    }

}

