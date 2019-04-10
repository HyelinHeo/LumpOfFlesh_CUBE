using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pointGroup;
    public GameObject numberGroup;

    private List<Transform> listPointGroup = new List<Transform>();
    private List<NumberControll> listNumberGroup = new List<NumberControll>();

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
                case "Cube_Top":
                    listNumberGroup[i].transform.rotation = Quaternion.EulerRotation(-90.0f, 90.0f, 0f);
                    break;
                case "Cube_Bottom":

                    break;
                case "Cube_Left":

                    break;
                case "Cube_Right":

                    break;
                case "Cube_Front":

                    break;
                case "Cube_Back":

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
