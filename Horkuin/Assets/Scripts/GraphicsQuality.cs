using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GraphicsQuality : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.value = PlayerPrefs.GetInt("GraphicsQuality", 4);
    }

    public void SetGraphicsQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality, true);
        PlayerPrefs.SetInt("GraphicsQuality", quality);
    }
}
