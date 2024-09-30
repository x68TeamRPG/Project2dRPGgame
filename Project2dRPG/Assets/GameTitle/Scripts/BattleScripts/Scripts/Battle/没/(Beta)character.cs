using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    // 名前
    public new string name; 
    // レベル
    public int level;
    // 体力
    public int hp;
    // マジックポイント
    public int Mp;
    // 攻撃力
    public int Atk;
    // 防御力
    public int Def;
    // 速さ
    public int spd;
    // 歩数
    public int step;
    // 
   //実行
    public CommandSO selectCommand;
    public character target;

    //持っている技
    public CommandSO[] commands;
}
