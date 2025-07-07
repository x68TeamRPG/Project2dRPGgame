using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleCommands : MonoBehaviour
{
    public TextController textController;
    public ItemController itemController;
    //通常エフェクト
    public EffectActive Attackeffect;
    //技1(middle)エフェクト
    public EffectActive Middleeffect;
    //技2(buff)エフェクト
    public EffectActive Buffeffect;
    //技3(great)エフェクト
    public EffectActive Greateffect;
    //アイテム1(Potion)エフェクト
    public EffectActive Potioneffect;
    //アイテム2(Elixir)エフェクト
    public EffectActive Elixireffect;
    //アイテム3(Ether)エフェクト
    public EffectActive Ethereffect;
    [SerializeField] private float damageDuration = 1.0f;

    void Start() {}

    public string CompareSpeed(Status player, Status enemy)
    {
        if (player.Speed >= enemy.Speed)
        {
            return "player";
        }
        else
        {
            return "enemy";
        }
    }

    public IEnumerator Attack(Status attacker, Status blocker, Waza normalAttack = null)
    {
        yield return new WaitForSeconds(1.0f);
        int damage = normalAttack.Execute(attacker, blocker);
        yield return StartCoroutine(textController.Write($"{attacker.name}の{normalAttack.jpname}！"));
        //エフェクト
        Attackeffect.PlayHitEffect();
        yield return StartCoroutine(textController.Write($"{blocker.name}に{damage}のダメージ"));
        yield return StartCoroutine(DamageRoll(damage, blocker));
    }

    public IEnumerator UseItem(Status Target, Item item)
    {
        yield return new WaitForSeconds(1.0f);
        yield return StartCoroutine(textController.Write($"{Target.name}は{item.jpname}を使用した！"));
        // エフェクト
        if (item.name == "Potion")
        {
            Potioneffect.PlayHitEffect();
        }
        else if (item.name == "Elixir")
        {
            Elixireffect.PlayHitEffect();
        }
        else if (item.name == "Ether")
        {
            Ethereffect.PlayHitEffect();
        }
        yield return StartCoroutine(textController.Write($"{Target.name}のHPが{item.healAmount}回復した！"));
        itemController.UseItem(item.name);
    }

    public IEnumerator UseWaza(Status attacker, Status blocker, Waza waza)
    {
        yield return new WaitForSeconds(1.0f);
        int damage = waza.Execute(attacker, blocker);
        yield return StartCoroutine(textController.Write($"{attacker.name}の{waza.jpname}！"));
        // エフェクト
        if (waza.engname == "MiddleAttack")
        {
            Middleeffect.PlayHitEffect();
        }
        else if (waza.engname == "BuffAttack")
        {
            Buffeffect.PlayHitEffect();
        }
        else if (waza.engname == "GreatAttack")
        {
            Greateffect.PlayHitEffect();
        }
        yield return StartCoroutine(textController.Write($"{blocker.name}に{damage}ダメージ！"));
        yield return StartCoroutine(DamageRoll(damage, blocker));
    }

    protected IEnumerator DamageRoll(int damage, Status blocker)
    {
        // 現在HP分以上のダメージは与えられないように
        int actualRolls = Mathf.Min(damage, blocker.CurrentHP);
        Debug.Log($"DamageRoll: {actualRolls}を{blocker.name}に与えます");
        // 1 回あたりの待機時間
        float interval = damageDuration / actualRolls;

        for (int i = 0; i < actualRolls; i++)
        {
            blocker.CurrentHP = Mathf.Max(0, blocker.CurrentHP - 1);
            // ここでHPバーの更新アニメーションなどを呼ぶと◎
            yield return new WaitForSeconds(interval);
        }

        Debug.Log($"{damage} のダメージを {damageDuration} 秒かけて与えました");
    }

}

