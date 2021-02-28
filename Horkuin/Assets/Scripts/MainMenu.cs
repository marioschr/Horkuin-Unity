using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //public AudioSource myAudio;

    /*public void Start()
    {
        myAudio = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        myAudio.volume = PlayerPrefs.GetFloat("MusicVolume", 0.6f);
    }*/

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2 , LoadSceneMode.Additive);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
