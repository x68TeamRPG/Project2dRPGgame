using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save1 : MonoBehaviour
{
    private HeroStatus herostatus;
    public GameObject hero;
    // Start is called before the first frame update
    void Start()
    {
        herostatus = hero.GetComponent<HeroStatus>();
        Load();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Save()
    { PlayerPrefs.SetInt("Save_StepCount", herostatus.StepCount); }

    public void Load()
    { herostatus.StepCount = PlayerPrefs.GetInt("Save_StepCount", herostatus.StepCount); }
}
