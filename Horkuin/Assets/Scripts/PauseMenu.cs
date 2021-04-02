using UnityEngine;
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Αν ο χρήστης πατήσει ESC
        {
            if (GameIsPaused) { // Αν είναι paused κάνει resume ή το ανάποδο 
                Resume();
                HelpMenuResume();
            } else {
                Pause();
            }
        }  
        else if (Input.GetKeyDown(KeyCode.F1)) // F1 για την βοήθεια
        {
            if (!GameIsPaused) {
                if (HelpIsOpen) {
                    Cursor.lockState = CursorLockMode.Locked; // Κλειδώνουμε και κρύβουμε το cursor
                    Cursor.visible = false;
                    foreach (GameObject horse in horses)
                    {
                        horse.GetComponent<AudioSource>().UnPause(); // Συνεχίζουμε τον ήχο
                    } 
                    audio.SetActive(true);
                    helpResume.SetActive(false);
                    helpBack.SetActive(true);
                    helpMenuUI.SetActive(false);
                    character.enabled = true;
                    Time.timeScale = 1f; // Συνεχίζουμε τον χρόνο
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

    public void ToggleHelpIsOpen()
    {
        HelpIsOpen = !HelpIsOpen;
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
        foreach (GameObject horse in horses) // Σταματάμε τον ήχο
        {
            horse.GetComponent<AudioSource>().Pause();
        }
        pauseMenuUI.SetActive(true); // Εμφανίζουμε το UI
	audio.SetActive(false);
        character.enabled = false;
        Time.timeScale = 0f; // Σταματάμε τον χρόνο
        GameIsPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0); // Επιστροφή στο MainMenu
        Time.timeScale = 1f;
    }
}
