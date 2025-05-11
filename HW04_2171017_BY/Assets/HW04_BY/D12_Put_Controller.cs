using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D12_Put_Controller : MonoBehaviour
{
    bool isInTheArea;
    public GameObject Bowl;
    public GameObject TargetObjectToClone;
    public Transform PlayerCamera;
    public GameObject UI_Controller;

    void Start()
    {
        Bowl.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isInTheArea)
        {
            D12_UI_Controller UI_Script = UI_Controller.GetComponent<D12_UI_Controller>();
            int heartsPicked = UI_Script.GetPickCounts();
            if (heartsPicked > 0)
            {
                ThrowHeart();
            }
            else
            {
                print("collect more hearts");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSController")
        {
            isInTheArea = true;
            Bowl.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "FPSController")
        {
            isInTheArea = false;
            Bowl.SetActive(false);
        }
    }

    void ThrowHeart()
    {
        // UI의 heart 개수 감소
        UI_Controller.GetComponent<D12_UI_Controller>().Decrease_PickCounter();

        Vector3 Pos = PlayerCamera.position + PlayerCamera.forward;
        Quaternion Rot = Quaternion.Euler(PlayerCamera.forward);

        // heart(Clone) 생성
        GameObject Clone = Instantiate(TargetObjectToClone, Pos, Rot);
        Clone.SetActive(true);  // 생성 후 바로 활성화

        // Collider 설정: isTrigger를 false로 설정하여 충돌이 발생하도록
        Clone.GetComponent<Collider>().isTrigger = false;

        // Rigidbody 설정: useGravity를 true로 하여 물리적 영향 받도록
        Clone.GetComponent<Rigidbody>().useGravity = true;

        // 카메라 방향으로 힘을 주어 던지기
        Clone.GetComponent<Rigidbody>().AddForce(PlayerCamera.forward * 400f);
    }
}