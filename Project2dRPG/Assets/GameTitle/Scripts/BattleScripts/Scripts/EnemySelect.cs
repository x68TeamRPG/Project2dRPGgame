using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySelect : MonoBehaviour
{
    public GameObject enemy;
    public Button button;
    public GameObject panel;
    public GameObject TextWindow;
    public TextController textControl;
    void Start()
    {
        enemy.GetComponent<Button>().interactable = false;
        button.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void OnClickButton()
    {
        enemy.GetComponent<Button>().interactable = true;
        panel.SetActive(false);
        textControl.Write("敵を選択");
        Debug.Log("敵を選択");
    }

}
