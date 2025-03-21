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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hptext.text = string.Format("{0}" , CurrentHP);
        MaxHptext.text = string.Format("{0}" , MaxHP);
    }
}
