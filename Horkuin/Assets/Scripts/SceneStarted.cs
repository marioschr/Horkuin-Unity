using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStarted : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    void Start()
    {       
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        animator.SetTrigger("Fade In");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
