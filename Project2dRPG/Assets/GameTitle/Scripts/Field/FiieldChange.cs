using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FieldChange : MonoBehaviour
{
    public string targetSceneName; // 移動先シーンの名前
    public Vector3 spawnPosition; // 移動先の座標
    GameObject myObject;
    void Start()
    { myObject = GameObject.FindWithTag("Player"); }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("Player"))
        //{
        // 移動先の座標を保存してシーンを移動
        // PlayerPrefs.SetFloat("SpawnX", spawnPosition.x);
        //PlayerPrefs.SetFloat("SpawnY", spawnPosition.y);

        //Debug.Log("SpanX:" + spawnPosition.x + "SpanY:" + spawnPosition.y);
        // シーン移動
        HeroController myScript = myObject.GetComponent<HeroController>();
        myScript.SetPosition(spawnPosition);
        SceneManager.LoadScene(targetSceneName);
        //}
    }
}