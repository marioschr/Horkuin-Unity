using System;
using UnityEngine;

public class SceneStarted : MonoBehaviour
{
    public Animator animator;
    public static SceneStarted instance;
    public Camera camera;
    public GameObject audio;
    private static readonly int Property = Animator.StringToHash("Fade In");

    private void Awake()
    {
        instance = this;
    }
    public void Fade()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        animator.SetTrigger(Property);
	audio.SetActive(true);
        camera.GetComponent<AudioListener>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        throw new NotImplementedException();
    }

    private void OnTriggerStay(Collider other)
    {
        throw new NotImplementedException();
    }
}
