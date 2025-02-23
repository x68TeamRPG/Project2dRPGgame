using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishJudge : MonoBehaviour
{
    [SerializeField] HeroStatus  player = default;
    [SerializeField] EnemyStatus enemy = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.CurrentHP == 0)
        {
            //テキストウィンドウ制御クラス「力尽きた」
            SceneManager.LoadScene("GameoverScene");//ゲームオーバーシーンに以降
        }
        if(enemy.CurrentHP == 0)
        {
            //テキストウィンドウ制御クラス「敵に勝利」「お金をx,経験値をy,歩数をzを手に入れた」
            //敵の技をもっているかの判定
            SceneManager.LoadScene("FieldScene");//フィールドシーンに以降
        }
    }
}
