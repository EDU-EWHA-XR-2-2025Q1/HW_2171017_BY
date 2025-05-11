using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class D12_Pick_Controller : MonoBehaviour
{
    bool targetShowed = false;
    public GameObject Container;
    public GameObject UI_Controller;

    private void Start()
    {
        Container.SetActive(false);
    }

    public void OnHeartClicked(GameObject Heart)
    {
        if (targetShowed)
        {
            UI_Controller.GetComponent<D12_UI_Controller>().Increase_PickCounter();
            Destroy(Heart);
        }
        else
        {
            print("out of pick area");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSController")
        {
            targetShowed = true;
            Container.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "FPSController")
        {
            targetShowed = false;
            Container.SetActive(false);
        }
    }
}
