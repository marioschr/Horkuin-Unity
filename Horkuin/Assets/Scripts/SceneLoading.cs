using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator.SetTrigger("Fade In");
    }

    /*void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }*/

    /*IEnumerator LoadAsyncOperation()
    {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(2);

        while (gameLevel.progress < 0.9)
        {
            progressBar.fillAmount = gameLevel.progress * 10 / 9;
            yield return null;
        }
        animator.SetTrigger("Fade Out");
    }*/
}
