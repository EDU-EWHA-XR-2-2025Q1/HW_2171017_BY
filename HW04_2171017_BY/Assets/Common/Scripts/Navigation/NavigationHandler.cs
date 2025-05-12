/*===============================================================================
Copyright (c) 2018 PTC Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NavigationHandler : MonoBehaviour
{
    public string BackButtonNavigation = "[Name of Scene To Load]";
    public UnityEvent OnBackButtonPressed = new UnityEvent();
    
    public void HandleBackButtonPressed()
    {
        OnBackButtonPressed?.Invoke();
        if (SceneManager.GetActiveScene().name != BackButtonNavigation)
            LoadScene(BackButtonNavigation);
    }
    
    void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
            SceneManager.LoadScene(sceneName);
    }
}
