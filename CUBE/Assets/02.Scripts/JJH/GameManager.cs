using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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

        for (int i = 0; i < listNumberGroup.Count; i++)
        {
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
                    listNumberGroup[i].transform.Rotate(-90.0f, -90.0f, 0);
                    break;
                case "Point_Right":
                    listNumberGroup[i].transform.Rotate(-90.0f, 90.0f, 0);
                    break;
                case "Point_Front":
                    listNumberGroup[i].transform.Rotate(-90.0f, 0, 0);
                    break;
                case "Point_Back":
                    listNumberGroup[i].transform.Rotate(-90.0f, 180.0f, 0);
                    break;
                default:
                    break;
            }
        }
    }

    public static void ShuffleList<T>(List<T> list)
    {
        int random1;
        int random2;

        T tmp;

        for (int index = 0; index < list.Count; ++index)
        {
            random1 = UnityEngine.Random.Range(0, list.Count);
            random2 = UnityEngine.Random.Range(0, list.Count);

            tmp = list[random1];
            list[random1] = list[random2];
            list[random2] = tmp;
        }
    }
}
