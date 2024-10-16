using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class CommandSO : ScriptableObject
{
    public new string name;

    public virtual void Execute(character user, character target)
    {
          //target.hp -= at;
          //Debug.Log($"{user.name}の攻撃:{target.name}に{3}のダメージ:残りHP{target.hp}");
    }
}
