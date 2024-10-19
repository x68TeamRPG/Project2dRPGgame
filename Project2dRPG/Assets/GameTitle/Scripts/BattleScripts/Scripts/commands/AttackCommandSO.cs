using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackCommandSO : CommandSO
{
    [SerializeField] int damage;

    public override void Execute(character user, character target)
    {
        target.hp -= damage;
        Debug.Log($"{target.name}に{damage}のダメージ:残りHP{target.hp}");
    }
}
