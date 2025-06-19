using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CommandButtonInput : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource が見つかりません。GameObject に追加してください！");
        }
    }

    void Update()
    {
        // Zキーで選択中のボタンを押す
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject selectedObj = EventSystem.current.currentSelectedGameObject;
            if (selectedObj != null)
            {
                Button btn = selectedObj.GetComponent<Button>();
                if (btn != null && btn.interactable)
                {
                    // 音の再生（CommandSoundスクリプトにある音）
                    ButtonSound soundComponent = selectedObj.GetComponent<ButtonSound>();
                    if (soundComponent != null && soundComponent.sound != null)
                    {
                        audioSource.PlayOneShot(soundComponent.sound);
                    }

                    // ボタンをクリックしたような動作
                    btn.onClick.Invoke();
                }
            }
        }
    }
}