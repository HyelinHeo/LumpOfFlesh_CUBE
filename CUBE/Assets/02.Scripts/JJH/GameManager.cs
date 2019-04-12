using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WALL
{
    FRONT = 0,
    BACK,
    LEFT,
    RIGHT,
    TOP,
    BOTTOM,
}

public class GameManager : MonoBehaviour
{
    public int listSize;
    public GameObject spider;
    public static GameManager instance = null;

    public GameObject pointGroup;
    public GameObject numberGroup;
    public int countNumber = 1;

    private List<Transform> listPointGroup = new List<Transform>();
    private List<NumberControll> listNumberGroup = new List<NumberControll>();

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pointGroup.GetComponentsInChildren<Transform>(listPointGroup);
        numberGroup.GetComponentsInChildren<NumberControll>(listNumberGroup);
        listPointGroup.RemoveAt(0);
        ShuffleList(listPointGroup);
        SetNumberPosition();
    }

    public void ShuffleList<T>(List<T> list)
    {
        int random1;
        int random2;

        T tmp;

        for (int index = 0; index < (list.Count) * 10; ++index)
        {
            random1 = UnityEngine.Random.Range(0, list.Count);
            random2 = UnityEngine.Random.Range(0, list.Count);

            tmp = list[random1];
            list[random1] = list[random2];
            list[random2] = tmp;
        }
    }

    public List<Transform> GetPointGroup()
    {
        return listPointGroup;
    }

    //public void ClickPointGroup(int num)
    //{
    //    NumberControll temp = null;

    //    foreach (var item in listNumberGroup)
    //    {
    //        if (item.GetComponent<NumberControll>().GetNumber() == num)
    //        {
    //            temp = item;
    //        }
    //    }
    //    if (temp != null)
    //    {
    //        listNumberGroup.Remove(temp);
    //    }
    //    countNumber++;
    //    ShuffleList(listPointGroup);
    //    SetNumberPosition();
    //}




    public void ClickPointGroup(NumberControll test)
    {
        listNumberGroup.Remove(test);

        ShuffleList(listPointGroup);
        SetNumberPosition();
        listSize = listNumberGroup.Count;
    }

    public void SetNumberPosition()
    {
        for (int i = 0; i < listNumberGroup.Count; i++)
        {
            listNumberGroup[i].transform.eulerAngles = new Vector3(0, 180.0f, 0);
            listNumberGroup[i].transform.position = listPointGroup[i].transform.position;
            listNumberGroup[i].Text((i + 1).ToString());
            switch (listPointGroup[i].gameObject.tag)
            {
                case "Point_Top":
                    listNumberGroup[i].transform.Rotate(0, 180.0f, 180.0f);
                    break;
                case "Point_Bottom":

                    break;
                case "Point_Left":
                    listNumberGroup[i].transform.Rotate(90.0f, 180.0f, -90.0f);
                    break;
                case "Point_Right":
                    listNumberGroup[i].transform.Rotate(90.0f, 180.0f, 90.0f);
                    break;
                case "Point_Front":
                    listNumberGroup[i].transform.Rotate(90.0f, 0, 0);
                    break;
                case "Point_Back":
                    listNumberGroup[i].transform.Rotate(90.0f, 180.0f, 0);
                    break;
                default:
                    break;
            }
            listNumberGroup[i].SetWallTag(listPointGroup[i].gameObject.tag);
        }
    }

    public void SetSpiderRotation(WALL wallTag)
    {
        switch (wallTag)
        {
            case WALL.TOP:
                spider.transform.Rotate(180.0f, 0, 0);
                break;
            case WALL.BOTTOM:
                Debug.Log("");
                break;
            case WALL.LEFT:
                spider.transform.Rotate(90.0f, 0, 90.0f);
                break;
            case WALL.RIGHT:
                spider.transform.Rotate(90.0f, 90.0f, 0);
                break;
            case WALL.FRONT:
                spider.transform.Rotate(90.0f, 0, 0);
                break;
            case WALL.BACK:
                spider.transform.Rotate(90.0f, 180.0f, 0);
                break;
            default:
                break;
        }
    }
}
