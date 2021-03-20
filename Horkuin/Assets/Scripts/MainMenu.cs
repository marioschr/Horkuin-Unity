using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Animator animator;
    private static readonly int FadeIn = Animator.StringToHash("Fade In");

    private void Awake()
    {
        animator.SetTrigger(FadeIn);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicsQuality", 4), true);

    }

    public void StartGame()
    {
        GameManager.instance.LoadGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
