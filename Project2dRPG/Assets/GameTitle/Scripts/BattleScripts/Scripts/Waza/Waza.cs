using UnityEngine;

public class Waza : MonoBehaviour
{
    public new string name;
    public int damage;
    public int usedMP;

    public int CalculateDamage(int playerAttack, int enemyDefence)
    {
        return damage + playerAttack - enemyDefence;
    }
}
