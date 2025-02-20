using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Mapmove : MonoBehaviour
{
    [SerializeField] Mapmovedata Mapmovedata;

    [SerializeField] string movescene;
    [SerializeField] Vector3 Moveposition;
    [SerializeField] Vector3 Moverotation;

    //ゲームオブジェクトに侵入したら呼び出し
    void OnTriggerEnter2D(Collider2D other)
    {
        //ゲームオブジェクトにプレイヤータグがついているか確認
        if (other.tag == "Player")
        {

            // シーン移動先位置と向きをScriptableObjectで作ったmapmovedataに保存
            Mapmovedata.Iti = Moveposition;
            Mapmovedata.Muki = Moverotation;
            // シーン切り替え(movesceneで指定したマップへ移動)
            SceneManager.LoadScene(movescene);
        }
    }
}

