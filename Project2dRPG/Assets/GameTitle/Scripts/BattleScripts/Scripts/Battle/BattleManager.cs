using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
  [SerializeField] HeroStatus  player = default;
  [SerializeField] EnemyStatus enemy = default;

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
                   
                //どっちか死ぬまで
                    if (player.CurrentHP <= 0 || enemy.CurrentHP <= 0)
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

