using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class SaveUIChange : MonoBehaviour
{
    private HeroStatus herostatus;
    private Status status;

    public Text textUI;
    public GameObject hero;

    [SerializeField] Text VarText;
    public void UIChange()
    {

        herostatus = hero.GetComponent<HeroStatus>();
        status = hero.GetComponent<Status>();
        VarText.text = "Lv" + status.Attack + "  " + "歩数" + herostatus.StepCount;

    }
}
