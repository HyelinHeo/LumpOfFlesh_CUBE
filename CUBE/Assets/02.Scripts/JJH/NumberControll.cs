using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NumberControll : MonoBehaviour, IPointerClickHandler
{
    private Text number;
    private int num = 0;

    private void Awake()
    {
        number = GetComponentInChildren<Text>();
    }

    public void Text( string value)
    {
        number.text = value;
        num = int.Parse(value);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(gameObject.tag.Equals("Number"))
        {
           if(num == GameManager.instance.countNumber)
            {
                gameObject.SetActive(false);
                GameManager.instance.countNumber++;
            }
        }
    }
}
