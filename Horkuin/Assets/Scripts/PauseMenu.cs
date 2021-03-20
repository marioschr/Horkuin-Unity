﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI, optionsMenuUI, helpMenuUI,helpBack,helpResume, audio;
    public static bool GameIsPaused = false, HelpIsOpen = false;
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
            if (!HelpIsOpen) {
                if (GameIsPaused) {
                    Resume();
                } else {
                    Pause();
                }
            }
        }  
        else if (Input.GetKeyDown(KeyCode.F1))
        {
            if (!GameIsPaused) {
                if (HelpIsOpen) {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    foreach (GameObject horse in horses)
                    {
                        horse.GetComponent<AudioSource>().UnPause();
                    }
		    audio.SetActive(true);
                    helpResume.SetActive(false);
                    helpMenuUI.SetActive(false);
                    character.enabled = true;
                    Time.timeScale = 1f;
                    HelpIsOpen = false;
                }
                else {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    foreach (GameObject horse in horses)
                    {
                        horse.GetComponent<AudioSource>().Pause();
                    }
                    helpMenuUI.SetActive(true);
                    helpBack.SetActive(false);
                    helpResume.SetActive(true);
		    audio.SetActive(false);
                    character.enabled = false;
                    Time.timeScale = 0f;
                    HelpIsOpen = true;
                }
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
	audio.SetActive(true);
        character.enabled = true;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void HelpMenuResume() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        foreach (GameObject horse in horses)
        {
            horse.GetComponent<AudioSource>().UnPause();
        }
        helpResume.SetActive(false);
        helpBack.SetActive(true);
        helpMenuUI.SetActive(false);
	audio.SetActive(true);
        character.enabled = true;
        Time.timeScale = 1f;
        HelpIsOpen = false;
    }

    public void Pause() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        foreach (GameObject horse in horses)
        {
            horse.GetComponent<AudioSource>().Pause();
        }
        pauseMenuUI.SetActive(true);
	audio.SetActive(false);
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
