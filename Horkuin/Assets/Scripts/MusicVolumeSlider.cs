using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    private AudioSource myAudio;
    private void Start()
    {
        GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume", 0.6f);
    }
    // Όρίζουμε την ένταση της μουσικής
    public void SetVolume(float sliderValue)
    {
        myAudio = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        myAudio.volume = sliderValue;
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
}
