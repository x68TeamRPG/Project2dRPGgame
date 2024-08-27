using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackCommandSO : CommandSO
{
    [SerializeField] int at;

    public override void Execute(character user, character target)
    {
        target.hp -= at;
        Debug.Log($"{target.name}に{at}のダメージ:残りHP{target.hp}");
    }
}
