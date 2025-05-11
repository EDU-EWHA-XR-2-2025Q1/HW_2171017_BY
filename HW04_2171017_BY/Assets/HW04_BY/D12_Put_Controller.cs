using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class D12_Put_Controller : MonoBehaviour
{
    bool isInTheArea;
    public GameObject BowlContainer;
    // public GameObject TargetObjectToClone;
    // public Transform PlayerCamera;
    public GameObject UI_Controller;
    public GameObject Bowl;

    private ObserverBehaviour mObserverBehaviour;
    private float timer = 0f;
    private float interval = 1f;
    private int[] possibleXPositions = { -10, -8, -6, -4, -2, 0, 2, 4, 6, 8, 10 };


    void Start()
    {
        mObserverBehaviour = GetComponent<ObserverBehaviour>();
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        BowlContainer.SetActive(false);
    }


    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        Debug.Log("Target status: " + behaviour.TargetName + " " + targetStatus.Status);

        if (targetStatus.Status == Status.EXTENDED_TRACKED || targetStatus.Status == Status.TRACKED)
        {
            BowlContainer.SetActive(true);
            Bowl.SetActive(true);
        }
    }

    void Update()
    {
        if(BowlContainer.activeSelf)
        {
            timer += Time.deltaTime;
            
            if (timer >= interval)
            {
                timer = 0f;

                // 랜덤한 X 좌표 선택
                int randomX = possibleXPositions[Random.Range(0, possibleXPositions.Length)];

                // 기존 위치 유지하면서 X만 변경
                Vector3 currentPos = Bowl.transform.position;
                Bowl.transform.position = new Vector3(randomX, currentPos.y, currentPos.z);
            }
        }
    }



    /*
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
    */
    /*
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
    }*/
}