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
        animator.SetTrigger("Fade Out");
        Invoke("LoadScene", 3f);
    }

    void LoadScene()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
