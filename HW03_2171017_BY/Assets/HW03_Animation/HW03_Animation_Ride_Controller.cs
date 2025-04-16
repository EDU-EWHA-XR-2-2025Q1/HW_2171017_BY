using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW03_Animation_Ride_Controller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Vehicle")
        {
            transform.SetParent(other.transform);
            transform.position = other.transform.position + Vector3.up *2f;

            // VehicleController�� ���� ���� �Լ� ȣ��
            HW03_Animation_Vehicle_Controller vehicleController = other.GetComponent<HW03_Animation_Vehicle_Controller>();

            if (vehicleController != null)
            {
                vehicleController.SetDirectionFromCurrentPosition();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Vehicle")
        {
            transform.SetParent(null);
        }
    }
}
