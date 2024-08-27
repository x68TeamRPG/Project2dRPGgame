using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    // HP
    public new string name; 
    public int hp;
   //実行
    public CommandSO selectCommand;
    public character target;

    //持っている技
    public CommandSO[] commands;
}
