using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class ItemDataBase
{
    private static List<Item> allItems = new List<Item>
    {
        new Item { itemName = "Potion", description = "HPを50回復", healAmount = 50 },
        new Item { itemName = "Elixir", description = "HPを全回復", healAmount = 100 }
    };

    public static Item GetItemByName(string itemName)
    {
        return allItems.FirstOrDefault(i => i.itemName == itemName);
    }
}
