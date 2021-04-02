using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStarted : MonoBehaviour
{
    public Animator animator;
    public static SceneStarted instance;
    public Camera camera;
    public GameObject audio;
    private static readonly int FadeIn = Animator.StringToHash("Fade In");

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
 
    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
 
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) { // Όταν φορτωθεί το GameScene να γίνει το ActiveScene
        SceneManager.SetActiveScene(scene);
    }
    
    private void Awake()
    {
        instance = this;
    }
    public void Fade() // Fade In για ομαλό άνοιγμα της σκηνής
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        animator.SetTrigger(FadeIn); 
        audio.SetActive(true);
        camera.GetComponent<AudioListener>().enabled = true;
    }
}
