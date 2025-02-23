using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Unity で、1文字ずつ表示するためのコード
 */
public class TextControl : MonoBehaviour
{

    //*******************************************************************
    //                Unityで設定
    //*******************************************************************

    /// メッセージパネル（ボタン）
    public GameObject TextWindow;
    public GameObject CommandPanel;

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

    public List<string> TextLists = new List<string> ();
    
    
    /// ゲームスタート時の処理
    void Start ()
    {
        //メッセージパネルに書かれている文字を消す
        Clean ();
        TextLists.Add("敵が現れた！\n");
        TextLists.Add("戦闘開始！");
    }

    public TextControl(GameObject TextWindow, GameObject CommandPanel, string text="", float WriteSpeed=0.2f, bool IsWriting=false)
    {
        this.TextWindow = TextWindow;
        this.CommandPanel = CommandPanel;
        this.text.text = text;
        this.WriteSpeed = WriteSpeed;
        this.IsWriting = IsWriting;

        Debug.Log(this.TextWindow == null ? "TextWindow is null" : "TextWindow is set");
        Debug.Log(this.CommandPanel == null ? "CommandPanel is null" : "CommandPanel is set");
        Debug.Log(this.text == null ? "text is null" : "text is set");
        Debug.Log(this.WriteSpeed == 0.2f ? "WriteSpeed is default" : "WriteSpeed is set");
        Debug.Log(this.IsWriting == false ? "IsWriting is default" : "IsWriting is set");
        Debug.Log(this.TextLists == null ? "TextLists is null" : "TextLists is set");
        Debug.Log("NovelWriter is created");
    }

    public void SetText (string text)
    {
        this.text.text = text;
    }

    public void Write (string text)
    {
        /* テキストをテキストウィンドウに表示するメソッド */
        WriteSpeed = 0.2f;
        Clean();
        StartCoroutine (IEWrite (text));
    }

    public void Clean ()
    {
        /* テキストを消すメソッド */
        text.text = "";
    }

    public void OnClick ()
    {
        //*******************************************************************
        //                メッセージパネルがクリックされた時の処理
        //*******************************************************************
        
        //前のメッセージを書いている途中かどうかで分ける
        if (IsWriting)
        {
            //書いている途中にクリックされた時------------------------------

            //スピード(かかる時間)を 0 にして、すぐに最後まで書く
            WriteSpeed = 0f;
        }
        else
        {
            //書き終わったあとでクリックされた時----------------------------
            if (TextLists.Count == 0)
            {
                //メッセージが全部終わった時---------------------------
                TextWindow.GetComponent<Button>().interactable = false;
                Clean ();
                //コマンドパネルを表示する
                CommandPanel.SetActive (true);
            }
            else
            {
                //メッセージが残っている時---------------------------

                //メッセージを書く
                Clean ();
                Write (TextLists[0]);
                TextLists.RemoveAt (0);
            }
        }
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
