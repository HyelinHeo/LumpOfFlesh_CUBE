using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NumberControll : MonoBehaviour, IPointerClickHandler
{
    private int num = 0;
    private WALL wall = WALL.BACK;

    public void Text( string value)
    {
       // number.text = value;
        num = int.Parse(value);
    }

    public void SetWallTag(string strWall)
    {
        switch (strWall)
        {
            case "Point_Top":
                wall = WALL.TOP;
                break;
            case "Point_Bottom":
                wall = WALL.BOTTOM;
                break;
            case "Point_Left":
                wall = WALL.LEFT;
                break;
            case "Point_Right":
                wall = WALL.RIGHT;
                break;
            case "Point_Front":
                wall = WALL.FRONT;
                break;
            case "Point_Back":
                wall = WALL.BACK;
                break;
            default:
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("number");
        if (gameObject.tag.Equals("Number"))
        {
           if(num == GameManager.instance.countNumber)
            {
                GameManager.instance.ClickPointGroup(this);
                gameObject.SetActive(false);

                if(GameManager.instance.listSize == 18)
                {
                    GameManager.instance.spider.transform.position = transform.position + new Vector3(0, 0.2f, 0);
                    GameManager.instance.SetSpiderRotation(wall);
                }
            }
        }
    }

    public int GetNumber()
    {
        return num;
    }
}
