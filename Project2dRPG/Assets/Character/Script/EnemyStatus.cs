using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : Status
{
    public Text Hptext;
   //マジックポイントの数値
    public Text MaxHptext;
   //最大マジックポイントの数値

    public int money;
    public int exp;
    public int step;
    public Waza waza;

    // Start is called before the first frame update
    void Start()
    {
        waza = new Waza("MiddleAttack", 10, 0, 0, true, true);
    }

    // Update is called once per frame
    void Update()
    {
        Hptext.text = string.Format("{0}" , CurrentHP);
        MaxHptext.text = string.Format("{0}" , MaxHP);
    }
}
