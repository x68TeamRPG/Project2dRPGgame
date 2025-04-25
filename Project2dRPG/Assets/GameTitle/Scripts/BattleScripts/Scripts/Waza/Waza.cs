public class Waza
{
    public string name;
    public int damage;
    public int usedMP;

    public Waza(string name, int damage, int usedMP, int usedStep, bool isPlayerHas, bool isEnemyHas)
    {
        this.name = name;
        this.damage = damage;
        this.usedMP = usedMP;
    }

    public int CalculateDamage(int playerAttack, int enemyDefence)
    {
        return damage + playerAttack - enemyDefence;
    }
}
