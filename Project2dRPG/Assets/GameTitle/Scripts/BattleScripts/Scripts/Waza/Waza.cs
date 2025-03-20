using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waza
{
    public string name;
    public int damage;
    public int usedMP;
    public int usedStep;
    public bool isPlayerHas;
    public bool isEnemyHas;

    public Waza(string name, int damage, int usedMP, int usedStep, bool isPlayerHas, bool isEnemyHas)
    {
        this.name = name;
        this.damage = damage;
        this.usedMP = usedMP;
        this.usedStep = usedStep;
        this.isPlayerHas = isPlayerHas;
        this.isEnemyHas = isEnemyHas;
    }
}
