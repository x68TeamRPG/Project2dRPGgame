using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class ItemDataBase
{
    private static List<Item> allItems = new List<Item>
    {
        new Item { type = 1, name = "Potion", jpname = "ポーション", description = "HPを50回復", healAmount = 50 },
        new Item { type = 1, name = "Elixir", jpname = "エリクサー", description = "HPを全回復", healAmount = 100 },
        new Item { type = 2, name = "Ether", jpname = "エーテル", description = "MPを50回復", healAmount = 50 }
    };

    public static Item GetItemByName(string name)
    {
        return allItems.FirstOrDefault(i => i.name == name);
    }
}
