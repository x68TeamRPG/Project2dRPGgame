using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NPCController : MonoBehaviour
{
    public GameObject dialogue;
    public Text Text;

   [SerializeField] 
   string words = "ここにセリフ";

   private bool flag = true; //talkコルーチンのフラグ

   void Start(){
    Text.text = words;
   }

   private bool stay = false;

   private void Update()
   {
    if(stay && Input.GetKey(KeyCode.Return) && flag){
        StartCoroutine(talk());
    }
   }

    private void OnTriggerStay2D(Collider2D other)
     {
        Debug.Log("ぶつかってるよ！");
        if (other.gameObject.CompareTag("Player"))
        {
            stay=true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            stay = false;  // プレイヤーが範囲外に出たらリセット
        }
    }

    IEnumerator talk(){
        dialogue.SetActive (true);
        yield return new WaitForSeconds(0.5f);
        while(flag){
        if(Input.GetKey(KeyCode.Return)){
            flag=false;
            StartCoroutine(talkend());
            break;
        }
        yield return null;
        }
    }

IEnumerator talkend()
{
    dialogue.SetActive(false);
    Debug.Log("通ったよ！");
    yield return new WaitForSeconds(1.0f);
    flag=true;
    yield return null;
}

}