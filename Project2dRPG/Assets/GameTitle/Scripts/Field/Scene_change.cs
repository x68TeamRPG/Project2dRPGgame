using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_change : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Mori");//移動先のシーンの名前を必ずafterにしてください！
        }
    }

}