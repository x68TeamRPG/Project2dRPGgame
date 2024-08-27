using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle : MonoBehaviour
{
    //フェーズ管理
    [SerializeField] character player = default;
    [SerializeField] character enemy = default;
    enum Phase
    {
        start,
        command,
        execute,
        result,
        end,
    }
    Phase phase;

    void Start()
    {
        phase = Phase.start;
        StartCoroutine(Battle());
    }

    IEnumerator Battle()
    {
        while (phase != Phase.end)
        {
            yield return null;
            Debug.Log(phase);
            switch(phase)
            {
                case Phase.start:
                    phase = Phase.command;
                    break;
                case Phase.command:
                //選択して実行
                //待機
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                //次のフェーズへ
                   player.selectCommand = player.commands[1];
                   player.target = player;
                   enemy.selectCommand = enemy.commands[0];
                   enemy.target = enemy;
                    phase = Phase.execute;
                    break;
                case Phase.execute:
                    player.selectCommand.Execute(player,player.target);
                    enemy.selectCommand.Execute(enemy,enemy.target);
                    //どっちか死ぬまで
                    if (player.hp <= 0 || enemy.hp <= 0)
                    {
                        phase = Phase.result;
                    }
                    else
                    {
                        phase = Phase.command;
                    }
                    break;
                case Phase.result:
                    phase = Phase.end;
                    break;
                case Phase.end:
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
