using UnityEngine;

public class SceneStarted : MonoBehaviour
{
    public Animator animator;
    public static SceneStarted instance;
    public Camera camera;

    private void Awake()
    {
        instance = this;
    }
    public void Fade()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        animator.SetTrigger("Fade In");
        camera.GetComponent<AudioListener>().enabled = true;
    }
}
