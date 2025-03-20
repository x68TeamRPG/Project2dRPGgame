using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WazaDB
{
    private Dictionary<string, Waza> wazaDB = new Dictionary<string, Waza>();

    public WazaDB()
    {
        wazaDB.Add("MiddleAttack", new Waza("MiddleAttack", 10, 0, 0, true, true));
        wazaDB.Add("HighAttack", new Waza("HighAttack", 20, 0, 0, true, true));
        wazaDB.Add("BuffAttack", new Waza("LowAttack", 0, 0, 0, true, true));
    }

    public void AddWaza(Waza waza)
    {
        wazaDB.TryGetValue(waza.name, out Waza w);
        if (w != null)
        {
            w.isPlayerHas = true;
        }
    }

    public Waza GetWaza(string name)
    {
        wazaDB.TryGetValue(name, out Waza waza);
        return waza;
    }

    public bool HasWaza(string name)
    {
        return wazaDB.ContainsKey(name);
    }
}
