using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public void OnClick_LoadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Scene01")
        {
            SceneManager.LoadScene("Scene02");
        }
        else if (currentSceneName == "Scene02")
        {
            SceneManager.LoadScene("Scene01");
        }
    }
}
