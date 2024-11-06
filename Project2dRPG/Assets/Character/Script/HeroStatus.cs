using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HeroStatus : Status
{
    int StepCount=10;
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

    public void AddStepCount(int n){
        StepCount+=n;
        Debug.Log(StepCount);
    }
    public void SubStepCount(int n){
        if(StepCount<=0){
            SubHP(1);
        }
        else{
            StepCount-=n;
            Debug.Log(StepCount);
        }
    }

    public void SubHP(int n){
        CurrentHP-=n;
        Debug.Log(CurrentHP);
        if(CurrentHP<=0){
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
