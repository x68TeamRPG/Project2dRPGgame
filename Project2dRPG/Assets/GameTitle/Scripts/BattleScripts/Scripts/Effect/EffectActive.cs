using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class EffectActive : MonoBehaviour
{
    public GameObject hitEffectPrefab;
    public Camera mainCamera;
    public AudioClip hitSound;
    private AudioSource audioSource;

    void Start()
    {
        // AudioSourceを取得
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSourceがありません");
        }
    }

    //テスト用:ボタンから画面中央に再生
    public void PlayEffect()
    {
        Vector3 centerPos = GetScreenCenterWorldPosition();
        SpawnEffectAt(centerPos);
    }

    //本番用:任意の位置にエフェクト＋音
    public void PlayHitEffect(Vector3 position)
    {
        SpawnEffectAt(position);
    }

    //画面中央のワールド座標を取得
    private Vector3 GetScreenCenterWorldPosition()
    {
        if (mainCamera == null)
        {
            Debug.LogWarning("カメラが設定されていません！");
            return Vector3.zero;
        }

        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 5f);
        return mainCamera.ScreenToWorldPoint(screenCenter);
    }

    //エフェクトと音を再生
    private void SpawnEffectAt(Vector3 worldPosition)
    {
        if (hitEffectPrefab != null)
        {
            Instantiate(hitEffectPrefab, worldPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("エフェクトのプレハブが設定されていません！");
        }

        if (hitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
        else
        {
            Debug.LogWarning("効果音（AudioClip）または AudioSource が設定されていません！");
        }
    }
}