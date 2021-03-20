using UnityEngine;

public class SceneLoading : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator.SetTrigger("Fade In");
    }
}
