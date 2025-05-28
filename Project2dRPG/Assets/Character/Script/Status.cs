using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int Attack = 10;
    public int Deffence = 10;
    public int Speed = 10;
    public int MaxHP = 10;
    public int CurrentHP = 10;
    public int MaxMP = 10;
    public int CurrentMP = 10;
    public bool IsBuffed = false;
    public int BuffTurns = 0;
    public int BuffAttackPoint = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateStatus()
    {
        if (IsBuffed)
        {
            BuffTurns--;
            if (BuffTurns <= 0)
            {
                ResetBuff();
            }
        }
    }

    private void ResetBuff()
    {
        IsBuffed = false;
        BuffTurns = 0;
        BuffAttackPoint = 0;
    }
}
