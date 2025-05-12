using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class D12_UI_Controller : MonoBehaviour
{
    public TMP_Text Heart_PickCounts, Heart_PutCounts;
    public static int pickCounter, putCounter;
    public static int cloneCount = 10;

    void Start()
    {
        Heart_PickCounts.text = pickCounter.ToString();
        Heart_PutCounts.text = putCounter.ToString();
    }

    public void RetryScene()
    {
        // ���� ī���� �ʱ�ȭ
        pickCounter = 0;
        putCounter = 0;
        cloneCount = 10;

        // ���� Ȱ��ȭ�� ���� �ٽ� �ҷ�����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Increase_PickCounter()
    {
        print($"increase pickCounter");
        pickCounter ++;
        cloneCount--;
        Heart_PickCounts.text = pickCounter.ToString();
    }

    public void Decrease_PickCounter()
    {
        print($"decrease pickCounter");
        pickCounter--;
        Heart_PickCounts.text = pickCounter.ToString();
    }

    public void Increase_PutCounter()
    {
        print($"increase putCounter");
        putCounter ++;
        Heart_PutCounts.text = putCounter.ToString();
    }

    public int GetPickCounts()
    {
        return pickCounter;
    }
}
