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
    IEnumerator Battle()
    {
        while (phase != Phase.End)
        {
            yield return null;
            Debug.Log(phase);
            switch(phase)
            {
                case Phase.Start:
                //スタートウィンドウパネルが消失されたら
                    phase = Phase.Command;
                    break;
                case Phase.Command:
                    phase = Phase.Execute;
                    break;
                case Phase.Execute:
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


}

