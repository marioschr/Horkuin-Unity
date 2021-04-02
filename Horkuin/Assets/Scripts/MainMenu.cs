using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        // Ορίζουμε την ποιότητα των γραφικών
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicsQuality", 4), true);

    }

    public void StartGame() // Φορτώνουμε το GameScene
    {
        GameManager.instance.LoadGame();
    }

    public void QuitGame() // Έξοδος
    {
        Application.Quit();
    }
}
