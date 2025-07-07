using UnityEngine;

public class Waza : MonoBehaviour
{
    public string engname;
    public string jpname;
    public int damage;
    public int usedMP;

    public Waza()
    {
        engname = "normalAttack";
        jpname = "通常攻撃";
        damage = 1;
        usedMP = 0;
    }

    public Waza(string name, int damage, int usedMP)
    {
        this.engname = name;
        this.damage = damage;
        this.usedMP = usedMP;
    }

    public virtual int Execute(Status attacker, Status target)
    {
        // Perform the attack and return the damage dealt
        int Attack = attacker.Attack + attacker.BuffAttackPoint;
        int Defence = target.Deffence;
        int Damage = CalculateDamage(damage, Attack, Defence);
        return Damage;
    }

    public int CalculateDamage(int damage, int Attack, int Defence)
    {
        float r = Random.Range(0.8f, 1.0f);
        int totalDamage = (int)(50 * damage * Attack / Defence / 25 * r);
        Debug.Log($"Damage Calculation: 50 * {damage} * {Attack} / {Defence} / 25 * {r} = {totalDamage}");
        return totalDamage;
    }
}
