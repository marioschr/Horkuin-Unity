using UnityEngine;
using Random = UnityEngine.Random;

public class Music : MonoBehaviour
{
    AudioSource myAudio;
    public AudioClip[] myAnonymousMusic;
 
    void Start()
    {
        // Ρυθμίζουμε την ένταση και ξεκινάμε την μουσική
        myAudio = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        myAudio.volume = PlayerPrefs.GetFloat("MusicVolume",0.6f);
        playRandomMyAnonymousMusic();
    }

    private static Music instance = null;
    // Δημιουργάμε instance για να παραμείνει σε όλες τις σκηνές η μουσική

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
        // Αν δεν παίζει μουσική ξεκινάει
        if (!myAudio.isPlaying) playRandomMyAnonymousMusic();
        
        // Αν ο χρήστης πατήσει M αλλάζει τραγούδι
        if (Input.GetKeyDown(KeyCode.M)) playRandomMyAnonymousMusic();
        
    }
 
    void playRandomMyAnonymousMusic()
    {
        // Επιλογή τυχαία από το playlist όσο δεν είναι το τραγούδι που έπαιξε μόλις
        do {
            myAudio.clip = myAnonymousMusic[Random.Range(0, myAnonymousMusic.Length)];
        } while (myAudio.isPlaying == myAudio.clip);
        myAudio.Play();
    }
}
