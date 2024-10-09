using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
   //名前
   public new string name;
   // レベルの数値
   public Text Leveltext;
   //体力の数値
   public Text Hptext;
   //マジックポイントの数値
   public Text Mptext;
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

   public int Level;
   public int Hp;
   public int Mp;
   public int Atk;
   public int Def;
   public int Spd;
   public int Step;
   


   
   void Start()
   {
      Level = 1;
      Hp = 30;
      Mp = 5;
      Atk = 10;
      Def = 5;
      Spd = 10;
      Step = 50;
   }

   void Update()
   {
     Leveltext.text = string.Format("{0}" , Level);
     Hptext.text = string.Format("{0}" , Hp);
     Mptext.text = string.Format("{0}" , Mp);
     Atktext.text = string.Format("{0}" , Atk);
     Deftext.text = string.Format("{0}" , Def);
     Spdtext.text = string.Format("{0}" , Spd);
     Steptext.text = string.Format("{0}" , Step);
     Hptext2.text = string.Format("{0}" , Hp);
     Mptext2.text = string.Format("{0}" , Mp);
   }
}
