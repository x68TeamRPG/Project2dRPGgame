using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;//追加



public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    public FadeIn fadeIn;

    void Start()
    {

        Debug.Log("i");
        // 保存された位置があればその場所にプレイヤーを移動
        if (PlayerPrefs.HasKey("SpawnX") && PlayerPrefs.HasKey("SpawnY") && PlayerPrefs.HasKey("SpawnZ"))
        {
            float x = PlayerPrefs.GetFloat("SpawnX");
            float y = PlayerPrefs.GetFloat("SpawnY");
            float z = PlayerPrefs.GetFloat("SpawnZ");
            transform.position = new Vector3(x, y, z);

            // 座標情報をクリア
            PlayerPrefs.DeleteKey("SpawnX");
            PlayerPrefs.DeleteKey("SpawnY");
            PlayerPrefs.DeleteKey("SpawnZ");
        }
        fadeIn.CallCoroutine();
    }
    private void Awake()
    {


    }

    public async void MoveToScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);


    }


}