using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadHeroStatus : MonoBehaviour
{

    private HeroStatus herostatus;
    // Start is called before the first frame update
    void Start()
    {
        herostatus = GetComponent<HeroStatus>();
        if (PlayerPrefs.HasKey("Step"))
        {

            herostatus.StepCount = PlayerPrefs.GetInt("Step");
            PlayerPrefs.DeleteKey("Step");

            Debug.Log("移動後" + herostatus.StepCount);
        }
    }


}
