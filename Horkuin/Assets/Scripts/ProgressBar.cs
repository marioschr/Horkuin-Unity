﻿using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("GameObject/UI/Linear Progress Bar")]
public static void AddLinearProgressBar()
{
    GameObject obj = Instantiate(Resources.Load<GameObject>("UI/Linear Progress Bar"));
    obj.transform.SetParent(Selection.activeGameObject.transform, false);
}
    #endif
    public int minimum,maximum, current;
    public Image fill;
    public Color color;
    public Image mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;

        fill.color = color;
    }
}
