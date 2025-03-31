using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCount : MonoBehaviour
{
    public Text text;
    public String itemname;



    [SerializeField] Text VarText;


    void Update()
    {
        Item des = ItemDataBase.GetItemByName(itemname);
        int ItemCount = Inventory.items.Count(item => item.itemName == itemname);
        VarText.text = itemname + " " + ItemCount + "    " + des.description;

    }
}
