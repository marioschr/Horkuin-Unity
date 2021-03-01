using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Music : MonoBehaviour
{
    AudioSource myAudio;
    public AudioClip[] myAnonymousMusic;
 
    void Start()
    {
        myAudio = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        myAudio.volume = PlayerPrefs.GetFloat("MusicVolume",0.6f);
        playRandomMyAnonymousMusic();
    }

    private static Music instance = null;

    public static Music Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (!myAudio.isPlaying) playRandomMyAnonymousMusic();
        
        if (Input.GetKeyDown(KeyCode.F)) playRandomMyAnonymousMusic();
        
    }
 
    void playRandomMyAnonymousMusic()
    {
        do {
            myAudio.clip = myAnonymousMusic[Random.Range(0, myAnonymousMusic.Length)];
        } while (myAudio.isPlaying == myAudio.clip);
        myAudio.Play();
    }
}
