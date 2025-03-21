using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Unity で、1文字ずつ表示するためのコード
 */
public class NovelWriter : MonoBehaviour
{

    //*******************************************************************
    //                Unityで設定
    //*******************************************************************

    /// メッセージパネル（ボタン）
    public GameObject messagePanel;

    /// テキスト
    public Text text;
    /// コマンドパネル
    public GameObject commandPanel;

    //*******************************************************************
    //                情報と基本メソッド
    //*******************************************************************

    /// 書くスピード(短いほど早い)
    public float writeSpeed = 0.2f;

    /// 書いている途中かどうか
    public bool isWriting = false;

    /// 文章の番号は Key で表す
    public int key = 0;

    public NovelWriter(GameObject messagePanel, GameObject commandPanel, string text="", int key=0)
    {
        this.messagePanel = messagePanel;
        this.commandPanel = commandPanel;
        this.text.text = text;
        this.key = key;

        Debug.Log(this.messagePanel == null ? "messagePanel is null" : "messagePanel is set");
        Debug.Log(this.commandPanel == null ? "commandPanel is null" : "commandPanel is set");
        Debug.Log(this.text == null ? "text is null" : "text is set");
        Debug.Log(this.key == null ? "key is null" : "key is set");
        Debug.Log("NovelWriter is created");
    }

    /// テキストを書くメソッド
    
    public void SetKey(int key)
    {
        this.key = key;
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }
    public void Write (string s)
    {
        //メッセージパネルを表示する
        messagePanel.SetActive (true);
        Clean();
        //毎回、書くスピードを 0.2 に戻す------<戻したくない場合はここを消す>
        writeSpeed = 0.2f;

        StartCoroutine (IEWrite (s));
    }

    /// テキストを消すメソッド
    public void Clean ()
    {
        text.text = "";
    }

    //*******************************************************************
    //                表示するメッセージ
    //*******************************************************************

    static Dictionary<int, string> message = new Dictionary<int, string> ()
    { 
        //----\nは改行を表す----
        { 1, "敵が現れた\n"}, 
        { 2, "戦闘開始!"},
    };

    //*******************************************************************
    //                メッセージパネルがタッチされた時の処理
    //*******************************************************************

    //このメソッドが呼ばれる
    public void OnClick ()
    {
        //前のメッセージを書いている途中かどうかで分ける
        if (isWriting)
        {
            //書いている途中にタッチされた時------------------------------

            //スピード(かかる時間)を 0 にして、すぐに最後まで書く
            writeSpeed = 0f;
        }
        else
        {
            //書き終わったあとでタッチされた時----------------------------

            switch (key)
            {
                case 2:
                    // 2 を書いた後-----------------------

                    //一旦ここで溜まった文字を消す
                    Clean ();
                    commandPanel.SetActive (true);

                    break;

                default:
                    //それ以外の場合全て-----------------

                    //番号を 1 増やす
                    key++;

                    //メッセージを書く
                    Write (message[key]);

                    break;
            }
        }
    }

    //*******************************************************************
    //                その他
    //*******************************************************************

    /// 書くためのコルーチン
    IEnumerator IEWrite (string s)
    {
        //書いている途中の状態にする
        isWriting = true;
        //渡されたstringの文字の数だけループ
        for (int i = 0; i < s.Length; i++)
        {
            //テキストにi番目の文字を付け足して表示する
            text.text += s.Substring (i, 1);
            //次の文字を表示するまで少し待つ
            yield return new WaitForSeconds (writeSpeed);
        }
        //書いている途中の状態を解除する
        isWriting = false;
    }

    /// ゲームスタート時の処理
    void Start ()
    {
        //メッセージパネルに書かれている文字を消す
        Clean ();
    }
}
