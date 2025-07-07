using System.Collections;
using UnityEngine;
using UnityEngine.UI;

class EmenyStrategy : MonoBehaviour
{
    [Header("敵の行動を決定するための技リスト")]
    [SerializeField] public Waza[] WazaList;

    /// <summary>
    /// ランダムに技を選んで返す
    /// </summary>
    public Waza GetEnemyWaza()
    {
        // 敵の行動を決定するロジック
        // ここではランダムに技を選ぶ例を示す
        if (WazaList == null || WazaList.Length == 0)
        {
            Debug.LogError("WazaList is not set or empty.");
            return null;
        }
        int randomIndex = Random.Range(0, WazaList.Length);
        Waza selectedWaza = WazaList[randomIndex];
        Debug.Log($"Selected enemy Waza: {selectedWaza.jpname}");
        return selectedWaza;
    }
}