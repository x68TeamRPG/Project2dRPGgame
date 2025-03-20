using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class ItemController : MonoBehaviour
{
    private Item item;

    [SerializeField]
    public GameObject hero;
    private HeroStatus herostatus;


    void Start(){
         herostatus = hero.GetComponent<HeroStatus>();
    }


    public void AddItemByName(string itemName)//アイテム名で、アイテムをゲットする
    {
        // アイテム名で検索
        Item itemToAdd = ItemDataBase.GetItemByName(itemName); // 仮想的にデータベースから取得
        if (itemToAdd != null)
        {
            AddItem(itemToAdd);
        }
        else
        {
            Debug.Log(itemName + "というアイテムは存在しません！");
        }
    }

    public void AddItem(Item item)
    {
        Inventory.items.Add(item);
        Debug.Log(item.itemName + "を取得しました！");
    }

    public bool UseItem(string itemName)//アイテム名を指定して、アイテムを使用する。
    {
        bool success_to_use = false;
        item= Inventory.items.FirstOrDefault(i => i.itemName == itemName);
        if (item != null){
            if (item.type == 1 && herostatus.CompareHP() == 1)
            {
                herostatus.AddHP(item.healAmount);
                Inventory.items.Remove(item);
                success_to_use = true;
                Debug.Log(item.itemName + "を使用しました！");
            }
            else
            {
                Debug.Log("条件を満たさないため使用できませんでした。");
            }
        }
        return success_to_use;
    }
}

