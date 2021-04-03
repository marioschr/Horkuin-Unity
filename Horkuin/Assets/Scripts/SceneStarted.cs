using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStarted : MonoBehaviour
{
    public Animator animator;
    public static SceneStarted instance;
    public Camera camera;
    public GameObject audio;
    private static readonly int FadeIn = Animator.StringToHash("Fade In");
    
    private void Awake()
    {
        instance = this;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
