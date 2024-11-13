using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HeroStatus : Status
{
    public int StepCount = 10;
    int Exp;
    int Lv;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddStepCount(int n)
    {
        StepCount += n;
        Debug.Log(StepCount);
    }
    public void SubStepCount(int n)
    {
        if (StepCount <= 0) { }
        StepCount -= n;
        Debug.Log(StepCount);
    }
}
