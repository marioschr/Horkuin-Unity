using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    //private Slider slider;
    private AudioSource myAudio;
    private void Start()
    {
        //slider = GetComponent<Slider>();
        GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume", 0.6f);
    }
    
    public void SetVolume(float sliderValue)
    {
        myAudio = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        myAudio.volume = sliderValue;
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
}
