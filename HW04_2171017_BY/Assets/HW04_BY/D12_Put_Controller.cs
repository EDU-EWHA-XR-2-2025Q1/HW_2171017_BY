using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class D12_Put_Controller : MonoBehaviour
{
    bool isInTheArea;
    public GameObject BowlContainer;
    public GameObject TargetObjectToClone;
    public Transform PlayerCamera;
    public GameObject UI_Controller;
    public GameObject Bowl;

    public GameObject GuideText;
    public GameObject AimPoint;
    public GameObject FireButton;

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
            GuideText.SetActive(false);
            AimPoint.SetActive(true);
            FireButton.SetActive(true);
        }
    }

    void Update()
    {
        Button fireBtn = FireButton.GetComponent<Button>();
        if (D12_UI_Controller.pickCounter <= 0)
        {
            fireBtn.interactable = false;
        }
        else
        {
            fireBtn.interactable = true;
        }

        if (BowlContainer.activeSelf)
        {
            timer += Time.deltaTime;

            if (timer >= interval)
            {
                timer = 0f;

                // ������ X ��ǥ ����
                int randomX = possibleXPositions[Random.Range(0, possibleXPositions.Length)];

                // ���� ��ġ �����ϸ鼭 X�� ����
                Vector3 currentPos = Bowl.transform.position;
                Bowl.transform.position = new Vector3(randomX, currentPos.y, currentPos.z);
            }
        }
    }

    public void ThrowHeart()
    {
        // UI�� heart ���� ����
        UI_Controller.GetComponent<D12_UI_Controller>().Decrease_PickCounter();

        Vector3 Pos = PlayerCamera.position + PlayerCamera.forward;
        Quaternion Rot = Quaternion.Euler(PlayerCamera.forward);

        // heart(Clone) ����
        GameObject Clone = Instantiate(TargetObjectToClone, Pos, Rot);
        Clone.SetActive(true);  // ���� �� �ٷ� Ȱ��ȭ

        // Collider ����: isTrigger�� false�� �����Ͽ� �浹�� �߻��ϵ���
        Clone.GetComponent<Collider>().isTrigger = false;

        // Rigidbody ����: useGravity�� true�� �Ͽ� ������ ���� �޵���
        Clone.GetComponent<Rigidbody>().useGravity = true;

        // ī�޶� ���� + �������� ���� �־� ������
        Vector3 throwDirection = PlayerCamera.forward + PlayerCamera.up * 0.5f;
        Clone.GetComponent<Rigidbody>().AddForce(throwDirection.normalized * 400f);
    }
}