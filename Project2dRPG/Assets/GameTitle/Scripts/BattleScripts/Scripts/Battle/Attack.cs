using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    [SerializeField] HeroStatus  player = default;
    [SerializeField] EnemyStatus enemy = default;

    [SerializeField] Button button1;

    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        StartCoroutine(Battle());
    }

    IEnumerator Battle()
    {  
            if (0 < enemy.CurrentHP)
            {
                var HP = enemy.CurrentHP;
                var damage = player.Attack - enemy.Deffence;
                float damage1 = (1/damage);
                while (HP - damage < enemy.CurrentHP)
                {
                    enemy.CurrentHP -= 1;
                    //停止
                    yield return new WaitForSeconds(damage1);
                }
                Debug.Log($"敵に{player.Attack - enemy.Deffence}のダメージ");
            }
            else
            {
                Debug.Log($"敵はいない");
            }
        
    }
}

