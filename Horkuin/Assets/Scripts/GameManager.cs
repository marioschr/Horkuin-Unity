using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    }


    public void LoadGame()
    {
        loadingScreen.gameObject.SetActive(true); // Εμφάνιση του loading screen
        StartCoroutine(LoadSceneAsync(1)); // Φόρτωση του GameScene
        Cursor.lockState = CursorLockMode.Locked; // Κλειδώνουμε και κρύβουμε το cursor
        Cursor.visible = false;
    }

    private float totalSceneProgress;
    private float totalSpawnProgress;
    private static readonly int FadeOut = Animator.StringToHash("Fade Out");

    IEnumerator LoadSceneAsync(int levelIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(levelIndex);

        while (!op.isDone)
        {
            float progress =
                Mathf.Clamp01(op.progress / .9f); // Γεμίζει το Loading bar ανάλογα το ποσοστό loading του scene
            textField.text = $"Loading: {progress * 100} %";
            bar.current = Mathf.RoundToInt(progress * 100);
            yield return null;
        }

        animator.SetTrigger(FadeOut); // Μαυρίζουμε την οθόνη
        Invoke(nameof(DisableLoadingScreen), 3f);
    }

    void DisableLoadingScreen()
    {
        loadingScreen.gameObject.SetActive(false);
        fade.gameObject.SetActive(false);
        SceneStarted.instance.Fade();
    }
}