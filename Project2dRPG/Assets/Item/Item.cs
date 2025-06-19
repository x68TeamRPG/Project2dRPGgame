using System;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int type; //itemの種類　1なら体力回復　2ならMP回復　3なら歩数回復
    public string name; // アイテム名
    public string jpname; // アイテム名（日本語）
    public string description; // 説明文
    public int healAmount; // 回復量

}

