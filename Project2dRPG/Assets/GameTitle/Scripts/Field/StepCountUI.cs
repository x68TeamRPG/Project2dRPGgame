using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StepCountUI : MonoBehaviour
{
    private HeroStatus herostatus;
    [SerializeField] TextMeshProUGUI VarText;
    public GameObject hero;


    void Start()
    {
        herostatus = hero.GetComponent<HeroStatus>();

    }

    void Update()
    {
        VarText.text = "" + herostatus.StepCount;
    }
}
