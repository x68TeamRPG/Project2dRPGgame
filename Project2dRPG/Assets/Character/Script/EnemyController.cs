using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float turnaroundtime = 10000.0f;
    private float time;   
    [SerializeField]
    private Animator enemyAnim;
    private int flag = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (enemyAnim == null)
        {
            Debug.LogError("Animator not assigned!");
        }
        time=0.0f; turn();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= turnaroundtime){
            turn(); time=0.0f;
        }
    }

void turn(){
        switch(flag){
        case 1:
            enemyAnim.SetFloat("X", 0);
            enemyAnim.SetFloat("Y", -1);
            break;
        case 2:
            enemyAnim.SetFloat("X", -1);
            enemyAnim.SetFloat("Y", 0);
            break;
        case 3:
            enemyAnim.SetFloat("X", 0);
            enemyAnim.SetFloat("Y", 1);
            break;
        case 4:
            enemyAnim.SetFloat("X", 1);
            enemyAnim.SetFloat("Y", 0);
            break;
        }
        flag = Random.Range(1, 21) % 4 + 1; // 1, 2, 3, 4を循環
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("当たった!");
        SceneManager.LoadScene("BattleScene");
    }
}

