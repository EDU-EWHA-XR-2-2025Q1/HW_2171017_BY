using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW03_Animator1_Door1_Controller2 : MonoBehaviour
{
    public Animator Animator;

    private void OnTriggerEnter(Collider other)
    {
        Animator.SetInteger("Status", -1);
    }

    private void OnTriggerExit(Collider other)
    {
        Animator.SetInteger("Status", 0);
        
    }
}
