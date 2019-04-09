using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    public static string[] strPattern;
    public static bool endSettingPattern = false;

    void Start()
    {
        TextAsset data = Resources.Load("pattern_LYG", typeof(TextAsset)) as TextAsset;
        string temp = data.text.ToString();
        strPattern = temp.Split('\r', '\n', '|');
        endSettingPattern = true;
    }

    void Update()
    {

    }
}
