using System;
using System.Collections;
using System.Collections.Generic;
using AquariusMax.Medieval;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI, optionsMenuUI;
    public static bool GameIsPaused = false;
    public Animator character;

    private GameObject[] horses;
    
    private void Start()
    {
        horses = GameObject.FindGameObjectsWithTag("Animal");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        foreach (GameObject horse in horses)
        {
            horse.GetComponent<AudioSource>().UnPause();
        }
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        character.enabled = true;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        foreach (GameObject horse in horses)
        {
            horse.GetComponent<AudioSource>().Pause();
        }
        pauseMenuUI.SetActive(true);
        character.enabled = false;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        Time.timeScale = 1f;
        Destroy(GameObject.FindGameObjectWithTag("Spawns"));
        SceneManager.UnloadSceneAsync(2);
    }
}
