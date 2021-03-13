using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator.SetTrigger("Fade In");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicsQuality", 4), true);

    }

    public void StartGame()
    {
        GameManager.instance.LoadGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
