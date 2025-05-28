using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioClip sound;

    private void Awake()
    {
        // ボタンがクリックされたときに音を鳴らす
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(PlaySound);
        }
    }

    public void PlaySound()
    {
        if (sound != null)
        {
            // CommandButtonInputがアタッチされているオブジェクトからAudioSourceを探す
            AudioSource audioSource = FindObjectOfType<CommandButtonInput>()?.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.PlayOneShot(sound);
            }
        }
    }
}
