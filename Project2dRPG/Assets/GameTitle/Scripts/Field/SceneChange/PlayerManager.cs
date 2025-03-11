using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;//追加



public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;

    public GameObject fadeCanvas;
    void Start()
    {
        Invoke("findFadeObject", 0.02f);
    }
    private void Awake()
    {
        // シングルトンパターン: オブジェクトが重複して生成されないようにする
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // シーンをまたいでも削除されないように設定
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void MoveToScene(string sceneName)
    {
        fadeCanvas.GetComponent<FadeManager>().fadeOut();//フェードアウトフラグを立てる
        await Task.Delay(200);//暗転するまで待つ
        SceneManager.LoadScene(sceneName);

        fadeCanvas.GetComponent<FadeManager>().fadeIn();

    }

    public void PositionMove()
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
    }
    void findFadeObject()
    {
        fadeCanvas = GameObject.FindGameObjectWithTag("Fade");//Canvasをみつける
        fadeCanvas.GetComponent<FadeManager>().fadeIn();//フェードインフラグを立てる
    }
}