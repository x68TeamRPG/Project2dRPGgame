using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_chenge : MonoBehaviour
{
    public string targetSceneName; // 移動先シーンの名前
    public Vector3 spawnPosition; // 移動先の座標

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 移動先の座標を保存してシーンを移動
            PlayerPrefs.SetFloat("SpawnX", spawnPosition.x);
            PlayerPrefs.SetFloat("SpawnY", spawnPosition.y);
            PlayerPrefs.SetFloat("SpawnZ", spawnPosition.z);

            // シーン移動
            SceneManager.LoadScene(targetSceneName);
        }
    }
}