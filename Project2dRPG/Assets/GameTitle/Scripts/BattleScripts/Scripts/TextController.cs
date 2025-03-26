using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*
 * Unity で、1文字ずつ表示するためのコード
 */
public class TextController : MonoBehaviour
{

    //*******************************************************************
    //                Unityで設定
    //*******************************************************************

    /// メッセージパネル（ボタン）
    public Button TextWindow;
    public GameObject CommandPanel;
    public Button Enemy;
    public Button Attack;

    /// テキスト
    public Text text;
    /// コマンドパネル

    //*******************************************************************
    //                情報と基本メソッド
    //*******************************************************************

    /// 書くスピード(短いほど早い)
    public float WriteSpeed;

    /// 書いている途中かどうか
    public bool IsWriting;
    
    /// ゲームスタート時の処理
    void Start ()
    {
        //メッセージパネルに書かれている文字を消す
        EventSystem.current.SetSelectedGameObject(TextWindow.gameObject);
        TextWindow.onClick.AddListener (OnClickTextWindow);
        Attack.onClick.AddListener (OnClickAttack);
        Enemy.GetComponent<Button>().interactable = false;

        Clean ();
        StartCoroutine(StartBattle());
    }

    public IEnumerator Write (string text)
    {
        /* テキストをテキストウィンドウに表示するメソッド */
        WriteSpeed = 0.2f;
        Clean();
        TextWindow.GetComponent<Button>().interactable = true;
        yield return StartCoroutine (IEWrite (text));
        Debug.Log(text);
    }

    public void Clean ()
    {
        /* テキストを消すメソッド */
        text.text = "";
    }
    
    IEnumerator StartBattle()
    {
        yield return StartCoroutine(Write("敵が現れた！\n"));
        yield return StartCoroutine(Write("戦闘開始！"));
        TextWindow.GetComponent<Button>().interactable = false;
        CommandPanel.SetActive(true);
    }

    public void OnClickTextWindow ()
    {
        //メッセージパネルがクリックされた時の処理
        
        //前のメッセージを書いている途中かどうかで分ける
        if (IsWriting)
        {
            //書いている途中にクリックされた時------------------------------
            //スピード(かかる時間)を 0 にして、すぐに最後まで書く
            WriteSpeed = 0f;
        }
        else
        {
            Clean();
        }
    }

    public void OnClickAttack ()
    {
        //敵がクリックされた時の処理
        Enemy.GetComponent<Button>().interactable = true;
        CommandPanel.SetActive(false);
        Clean ();
        StartCoroutine(Write ("敵を選択"));
        TextWindow.GetComponent<Button>().interactable = false;
    }

    /// 書くためのコルーチン
    IEnumerator IEWrite (string text)
    {
        //書いている途中の状態にする
        IsWriting = true;
        //渡されたstringの文字の数だけループ
        for (int i = 0; i < text.Length; i++)
        {
            //テキストにi番目の文字を付け足して表示する
            this.text.text += text.Substring (i, 1);
            //次の文字を表示するまで少し待つ
            yield return new WaitForSeconds (WriteSpeed);
        }
        //書いている途中の状態を解除する
        IsWriting = false;
    }



}
