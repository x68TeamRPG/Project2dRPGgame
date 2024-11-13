using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NPCController : MonoBehaviour
{
    public GameObject dialogue;
    public Text Text;
    private int stringnumber =0;
    private HeroController herocontroller;

   [SerializeField] 
   string[] words;
   public GameObject hero;

   private bool flag = true; //talkコルーチンのフラグ

   void Start(){
    herocontroller = hero.GetComponent<HeroController>();
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
        flag=false;
        Text.text = words[stringnumber];
        dialogue.SetActive (true);
        herocontroller.isMoving();
        yield return new WaitForSeconds(0.5f);
        while(!flag){
        if(Input.GetKey(KeyCode.Return)){
            if(stringnumber+1 < words.Length){
                Debug.Log("通ったよ！");
                stringnumber=stringnumber+1;
                Text.text = words[stringnumber];
                yield return new WaitForSeconds(0.5f);
            }
            else{
                //flag=true;
                StartCoroutine(talkend());
                break;
            }
        }
        yield return null;
        }
    }

IEnumerator talkend()
{
    Debug.Log("falseです");
    dialogue.SetActive(false);
    stringnumber=0;
    herocontroller.notMoving();
    yield return new WaitForSeconds(1.0f);
    flag=true;
    yield return null;
}

}