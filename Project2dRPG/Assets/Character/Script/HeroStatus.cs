using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroStatus : Status
{
    public int StepCount=10;
    public int Exp;
    public int Lv;

    public new string name;
   // レベルの数値
   public Text Leveltext;
   //体力の数値
   public Text Hptext;
   //マジックポイントの数値
   public Text Mptext;
   //最大体力の数値
   public Text MaxHptext;
   //最大マジックポイントの数値
   public Text MaxMptext;
   // 攻撃力の数値
   public Text Atktext;
   //防御力の数値
   public Text Deftext;
   //速さの数値
   public Text Spdtext;
   //歩数の数値
   public Text Steptext;
   //体力の数値
   public Text Hptext2;
   //マジックポイントの数値
   public Text Mptext2;
   //最大体力2の数値
   public Text MaxHptext2;
   //最大マジックポイント2の数値
   public Text MaxMptext2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Leveltext.text = string.Format("{0}" , Lv);
        Hptext.text = string.Format("{0}" , CurrentHP);
        Mptext.text = string.Format("{0}" , CurrentMP);
        MaxHptext.text = string.Format("{0}" , MaxHP);
        MaxMptext.text = string.Format("{0}" , MaxMP);
        Atktext.text = string.Format("{0}" , Attack);
        Deftext.text = string.Format("{0}" , Deffence);
        Spdtext.text = string.Format("{0}" , Speed);
        Steptext.text = string.Format("{0}" , StepCount);
        Hptext2.text = string.Format("{0}" , CurrentHP);
        Mptext2.text = string.Format("{0}" , CurrentMP);
        MaxHptext2.text = string.Format("{0}" , MaxHP);
        MaxMptext2.text = string.Format("{0}" , MaxMP);
    }

    public void AddStepCount(int n)
    {
        StepCount += n;
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
