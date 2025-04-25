using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleCommands : MonoBehaviour
{
    public TextController textController;
    public ItemController itemController;

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
        int damage = waza.CalculateDamage(attacker.Attack, blocker.Deffence);
        yield return StartCoroutine(DamageRoll(damage, blocker));
        yield return StartCoroutine(textController.Write($"{attacker.name}は{waza.name}を使用した！"));
        yield return StartCoroutine(textController.Write($"{blocker.name}に{damage}ダメージ！"));
    }

    protected IEnumerator DamageRoll(int damage, Status blocker)
    {
        if (0 < blocker.CurrentHP)
        {
            int HP = blocker.CurrentHP;
            float damage1 = 1/damage;
            while (HP - damage < blocker.CurrentHP)
            {
                blocker.CurrentHP -= 1;
                //停止
                yield return new WaitForSeconds(damage1);
            }
        }
        Debug.Log($"{damage}のダメージ");
    }

}

