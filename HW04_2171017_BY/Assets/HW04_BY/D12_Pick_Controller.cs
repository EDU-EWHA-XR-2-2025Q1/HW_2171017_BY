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

    private TrackableBehaviour mTrackableBehaviour;

    private void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterOnTrackableEventHandler(this);
        }

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

    private void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Target found
            Container.SetActive(true);
        }
        else
        {
            // Target lost
            Container.SetActive(false);
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
