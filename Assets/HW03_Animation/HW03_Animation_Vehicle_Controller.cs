using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW03_Animation_Vehicle_Controller : MonoBehaviour
{
    public Animator Animator;
    public Transform child;

    public int status = -2;
    // -2: -30���� ����, -1: ������ �̵�, 1: �ڷ� �̵�, 2: 30���� ����

    private void Update()
    {
        // ���� z ��ġ Ȯ��
        float currentZ = transform.position.z;

        // Start���� �ڽ� ������Ʈ ã��
        child = transform.Find("FPSController");

        if (child != null)  // Player�� ž������ ��
        {
            if (status == -1) // -30 �� 30
            {
                if (currentZ < 30f)
                {
                    Animator.SetInteger("Status", -1);
                }
                else
                {
                    status = 2; // ������ ����
                    Animator.SetInteger("Status", 2);
                }
            }
            else if (status == 1) // 30 �� -30
            {
                if (currentZ > -30f)
                {
                    Animator.SetInteger("Status", 1);
                }
                else
                {
                    status = -2; // ������ ����
                    Animator.SetInteger("Status", -2);
                }
            }
            Animator.speed = 1f;
        }
        else
        {
            Animator.speed = 0f; // Player�� ž������ �ʾ��� �� �ִϸ��̼� ����
        }
    }

    public void SetDirectionFromCurrentPosition()
    {
        float z = transform.position.z;
        print(z);
        if (z <= -30f) status = -1; // ������ �̵�
        if (z >= 30f) status = 1; // �ڷ� �̵�
    }
}