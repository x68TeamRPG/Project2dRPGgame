using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Waza1CommandSO : CommandSO
{  
    [SerializeField] int healPoint;

    //上書き
    public override void Execute(character user, character target)
    {
        target.hp += healPoint;
        Debug.Log($"{target.name}に{healPoint}の回復:残りHP{target.hp}");
    }
}
