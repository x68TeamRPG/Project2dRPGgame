using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoukutu : MonoBehaviour
{
    Vector3 pos;
    [SerializeField]
    Mapmovedata mapmovedata = null;
    public GameObject hero;
    private GameObject Hero;
    void Start()
    {
        // posにシーン切り替え前に指定した位置を取得
        pos = mapmovedata.Iti;
        // プレハブを元に操作キャラのオブジェクトをposの位置に生成する。向き(角度)をここで指定することも可能だが、やや難解なのでここではやらない
        // 生成したゲームオブジェクトをplayerprefabに入れる。
        Hero = Instantiate(hero, pos, Quaternion.identity);
        //playerprefabの角度をシーン切り替え前に指定したものに変更
        Hero.transform.localEulerAngles = mapmovedata.Muki;

    }
}
