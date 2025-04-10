using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW03_Animation_Vehicle_Controller : MonoBehaviour
{
    public Animator Animator;
    public Transform child;

    public int status = -2;
    // -2: -30에서 정지, -1: 앞으로 이동, 1: 뒤로 이동, 2: 30에서 정지

    private void Update()
    {
        // 현재 z 위치 확인
        float currentZ = transform.position.z;

        // Start에서 자식 오브젝트 찾기
        child = transform.Find("FPSController");

        if (child != null)  // Player가 탑승했을 때
        {
            if (status == -1) // -30 → 30
            {
                if (currentZ < 30f)
                {
                    Animator.SetInteger("Status", -1);
                }
                else
                {
                    status = 2; // 목적지 도착
                    Animator.SetInteger("Status", 2);
                }
            }
            else if (status == 1) // 30 → -30
            {
                if (currentZ > -30f)
                {
                    Animator.SetInteger("Status", 1);
                }
                else
                {
                    status = -2; // 목적지 도착
                    Animator.SetInteger("Status", -2);
                }
            }
            Animator.speed = 1f;
        }
        else
        {
            Animator.speed = 0f; // Player가 탑승하지 않았을 때 애니메이션 정지
        }
    }

    public void SetDirectionFromCurrentPosition()
    {
        float z = transform.position.z;
        print(z);
        if (z <= -30f) status = -1; // 앞으로 이동
        if (z >= 30f) status = 1; // 뒤로 이동
    }
}