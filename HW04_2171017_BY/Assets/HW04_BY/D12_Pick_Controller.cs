using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Vuforia;


public class D12_Pick_Controller : MonoBehaviour
{
    bool targetShowed = false;
    public GameObject Container;
    public GameObject UI_Controller;

    private ObserverBehaviour mObserverBehaviour;

    private void Start()
    {
        mObserverBehaviour = GetComponent<ObserverBehaviour>();
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        Container.SetActive(false);
    }

    public void OnHeartClicked(GameObject Heart)
    {
        UI_Controller.GetComponent<D12_UI_Controller>().Increase_PickCounter();
        Destroy(Heart);
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        Debug.Log("Target status: " + behaviour.TargetName + " " + targetStatus.Status);

        if (targetStatus.Status == Status.EXTENDED_TRACKED || targetStatus.Status == Status.TRACKED)
        {
            targetShowed = true;
            Container.SetActive(true);
        }
    }
    /*
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
    }*/
}



