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

   void Start(){
    Text.text = words;
   }

    private void OnTriggerStay2D(Collider2D other)
     {
        if (other.gameObject.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.Return)){
                StartCoroutine(talk());
            }
        }
    }

    IEnumerator talk(){
        dialogue.SetActive (true);
        yield return new WaitForSeconds(5.0f);
        dialogue.SetActive(false);
    }
}