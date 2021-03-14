using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loadingScreen, fade;
    public ProgressBar bar;
    public Animator animator;
    public TextMeshProUGUI textField;
    private void Awake()
    {
        instance = this;

        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }

    private List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    
    public void LoadGame()
    {
        GameObject spawns= new GameObject("Spawns");
        spawns.gameObject.tag = "Spawns";
        loadingScreen.gameObject.SetActive(true);
        scenesLoading.Add(SceneManager.UnloadSceneAsync(1));
        scenesLoading.Add(SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive));
        StartCoroutine(GetSceneLoadProgress());
        StartCoroutine(GetTotalProgress());
    }

    private float totalSceneProgress;
    private float totalSpawnProgress;
    public IEnumerator GetSceneLoadProgress()
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                totalSceneProgress = 0;

                foreach (AsyncOperation operation in scenesLoading)
                {
                    totalSceneProgress += operation.progress;
                }
                totalSceneProgress = (totalSceneProgress / scenesLoading.Count) * 100f;
                textField.text = string.Format("Loading Environment: {0} %", totalSceneProgress);
                yield return null;
            }
        }
    }

    public IEnumerator GetTotalProgress()
    {
        float totalProgress = 0;

        while (PedestrianSpawner.current == null || !PedestrianSpawner.current.isDone)
        {
            if (PedestrianSpawner.current == null)
            {
                totalSpawnProgress = 0;
            }
            else
            {
                totalSpawnProgress = Mathf.Round(PedestrianSpawner.current.progress * 100f);
                textField.text = string.Format("Loading Pedestrians: {0} %", totalSpawnProgress);
            }
            
            totalProgress = Mathf.Round((totalSceneProgress + 5 + totalSpawnProgress) / 2f);
            bar.current = Mathf.RoundToInt(totalProgress);
            yield return null;
        }

        animator.SetTrigger("Fade Out");
        Invoke("DisableLoadingScreen",3f);
    }

    void DisableLoadingScreen()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(2));
        loadingScreen.gameObject.SetActive(false);
        fade.gameObject.SetActive(false);
        SceneStarted.instance.Fade();
    }
}
