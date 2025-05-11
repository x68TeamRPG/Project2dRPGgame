using UnityEngine;

public class Buff : Waza
{
    public int buffTurns = 3;
    public int buffAttackPoint = 5;
    void Start()
    {
        name = "BuffAttack";
        damage = 0;
        usedMP = 5;
        buffTurns = 3;
        buffAttackPoint = 5;
    }

    public override int Execute(Status attacker, Status target)
    {
        attacker.IsBuffed = true;
        attacker.BuffTurns = buffTurns;
        attacker.BuffAttackPoint = buffAttackPoint;
        return 0;
    }


}
