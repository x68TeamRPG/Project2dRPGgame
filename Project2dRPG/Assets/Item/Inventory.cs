using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
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
        items.Add(item);
        Debug.Log(item.itemName + "を取得しました！");
    }

    public void UseItem(string itemName)//アイテム名を指定して、アイテムを使用する。
    {
        item= items.FirstOrDefault(i => i.itemName == itemName);
        if (item != null)
        {
            herostatus.AddHP(item.healAmount);
            items.Remove(item);
            Debug.Log(item.itemName + "を使用しました！");
        }
        else
        {
            Debug.Log(itemName + "はインベントリにありません！");
        }
    }
}

