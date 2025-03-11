using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ChangeSceneOnCollision : MonoBehaviour
{
    public Vector3 spawnPosition;
    [SerializeField] private string targetSceneName; // 次のシーン名をInspectorで設定

    private async void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetFloat("SpawnX", spawnPosition.x);
            PlayerPrefs.SetFloat("SpawnY", spawnPosition.y);
            PlayerPrefs.SetFloat("SpawnZ", spawnPosition.z);

            Debug.Log("Playerが衝突しました。シーンを移動します: " + targetSceneName + spawnPosition.x);

            // PlayerManagerを通じてシーンを移動
            PlayerManager playerManager = other.GetComponent<PlayerManager>();
            if (playerManager != null)
            {

                playerManager.MoveToScene(targetSceneName);
                await Task.Delay(200);
                playerManager.PositionMove();

            }
        }
    }
}