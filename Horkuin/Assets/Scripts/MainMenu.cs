using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicsQuality", 4), true);

    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
