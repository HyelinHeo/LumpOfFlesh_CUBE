using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberControll : MonoBehaviour
{
    private Text number;

    private void Awake()
    {
        number = GetComponentInChildren<Text>();
    }

    public void Text( string value)
    {
        number.text = value;
    }
}
