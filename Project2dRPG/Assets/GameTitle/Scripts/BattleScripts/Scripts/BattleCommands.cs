using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleCommands : MonoBehaviour
{
    public TextController textController;
    public ItemController itemController;
    [SerializeField] private float totalDuration = 1.0f;

    void Start()
    {
        itemController = GetComponent<ItemController>();
    }

    public IEnumerator Attack(Status attacker, Status blocker)
    {
        yield return new WaitForSeconds(1.0f);
        int damage = attacker.Attack - blocker.Deffence;
        yield return StartCoroutine(DamageRoll(damage, blocker));
        yield return StartCoroutine(textController.Write($"{blocker.name}に{damage}のダメージ"));
    }

    public IEnumerator UseItem(Status Mono)
    {
        yield return new WaitForSeconds(1.0f);
        itemController.UseItem("Potion");
        yield return StartCoroutine(textController.Write($"{Mono.name}はポーションを使用した！"));
    }

    public IEnumerator UseWaza(Status attacker, Status blocker, Waza waza)
    {
        yield return new WaitForSeconds(1.0f);
        int damage = waza.Execute(attacker, blocker);
        yield return StartCoroutine(DamageRoll(damage, blocker));
        yield return StartCoroutine(textController.Write($"{attacker.name}は{waza.name}を使用した！"));
        yield return StartCoroutine(textController.Write($"{blocker.name}に{damage}ダメージ！"));
    }

    protected IEnumerator DamageRoll(int damage, Status blocker)
    {
        // 現在HP分以上のダメージは与えられないように
        int actualRolls = Mathf.Min(damage, blocker.CurrentHP);
        Debug.Log($"DamageRoll: {actualRolls}を{blocker.name}に与えます");
        // 1 回あたりの待機時間
        float interval = totalDuration / actualRolls;

        for (int i = 0; i < actualRolls; i++)
        {
            blocker.CurrentHP = Mathf.Max(0, blocker.CurrentHP - 1);
            // ここでHPバーの更新アニメーションなどを呼ぶと◎
            yield return new WaitForSeconds(interval);
        }

        Debug.Log($"{damage} のダメージを {totalDuration} 秒かけて与えました");
    }

}

