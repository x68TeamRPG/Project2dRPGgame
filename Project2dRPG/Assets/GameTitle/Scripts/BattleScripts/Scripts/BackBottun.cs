using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonController : MonoBehaviour
{
    [System.Serializable]
    public class Window
    {
        //パネル
        public GameObject windowObject;  
        //戻るボタン
        public Button backButton;        
    }

    [Tooltip("戻るボタンを管理する複数のウインドウを登録してください")]
    public List<Window> windows = new List<Window>();

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource が見つかりません。BackButtonControllerのあるGameObjectに追加してください。");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PressActiveWindowBackButton();
        }
    }

    private void PressActiveWindowBackButton()
    {
        foreach (Window w in windows)
        {
            if (w.windowObject != null && w.windowObject.activeInHierarchy)
            {
                if (w.backButton != null && w.backButton.interactable)
                {
                    PlayButtonSound(w.backButton.gameObject);
                    w.backButton.onClick.Invoke();
                    return;
                }
                else
                {
                    Debug.LogWarning($"戻るボタンが設定されていないか、interactableではありません。ウインドウ: {w.windowObject.name}");
                }
            }
        }
        Debug.Log("アクティブなウインドウが見つからないか、戻るボタンがありません。");
    }

    private void PlayButtonSound(GameObject buttonObj)
    {
        var soundComponent = buttonObj.GetComponent<ButtonSound>();
        if (soundComponent != null && soundComponent.sound != null && audioSource != null)
        {
            audioSource.PlayOneShot(soundComponent.sound);
        }
    }
}