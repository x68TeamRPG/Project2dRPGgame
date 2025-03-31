using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : MonoBehaviour
{
    [SerializeField]
    public Animator anim;
    private GameObject inv;
    private ItemController ic;
    private int flag;
    public int TresureNumber;//宝箱の番号
    
    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("ItemController");
        ic = inv.GetComponent<ItemController>();
        flag = PlayerPrefs.GetInt("treasure"+TresureNumber, 0); // デフォルト値は0
        if(flag==1){
            anim.SetFloat("isOpen",1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == 1) {
            Debug.Log("フラグがONです");
        }
    }

    void OnTriggerStay2D(Collider2D other){
        Debug.Log("ぶつかってるよ！");
        if (other.gameObject.CompareTag("Player") && (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Z)) && flag == 0)
        {
            anim.SetFloat("isOpen",1f);
            flag = 1;
            ic.AddItemByName("Potion");
            PlayerPrefs.SetInt("tresure"+TresureNumber,1);
        }
    }
}
