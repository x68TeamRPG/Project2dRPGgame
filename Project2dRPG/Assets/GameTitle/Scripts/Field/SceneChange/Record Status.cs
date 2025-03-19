using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class RecordStatus : MonoBehaviour
{
    private HeroStatus herostatus;
    public GameObject hero;


    private async void OnTriggerEnter2D(Collider2D other)
    {
        herostatus = hero.GetComponent<HeroStatus>();
        if (other.CompareTag("Player"))
        {

            PlayerPrefs.SetInt("Step", herostatus.StepCount);
            Debug.Log("移動前" + herostatus.StepCount);
        }


    }

}

