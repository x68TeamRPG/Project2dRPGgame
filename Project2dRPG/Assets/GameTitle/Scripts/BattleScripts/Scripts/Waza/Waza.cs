using UnityEngine;

public class Waza : MonoBehaviour
{
    public new string name;
    public int damage;
    public int usedMP;

    public virtual int Execute(Status attacker, Status target)
    {
        // Perform the attack and return the damage dealt
        int playerAttack = attacker.Attack + attacker.BuffAttackPoint;
        int enemyDefence = target.Deffence;
        int playerAttackPower = CalculateDamage(damage, playerAttack, enemyDefence);
        return playerAttackPower;
    }

    public int CalculateDamage(int damage, int playerAttack, int enemyDefence)
    {
        return damage + playerAttack - enemyDefence;
    }
}
