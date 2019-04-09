using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public Block blockPrefab;
    public Transform blockParent;
    private Block[] blocks = new Block[35];
    private readonly float blockSize = 1.0f;
    private readonly int x = 7;
    private readonly float originX = -3.0f;
    private readonly float originZ = -2.0f;

    void Start()
    {
        SetBlock();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetBlockPattern(Random.Range(0, Pattern.strPattern.Length));
        }
    }

    public void SetBlock()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            Block block = Instantiate<Block>(blockPrefab, blockParent);
            blocks[i] = block;
            blocks[i].name = "Block " + i.ToString();
            blocks[i].transform.localPosition = new Vector3(originX + (blockSize * (i % x)), -0.05f, originZ + (blockSize * (i / x)));
            blocks[i].gameObject.SetActive(false);
        }
    }

    public void SetBlockPattern(int index)
    {
        string[] pattern = Pattern.strPattern[index].Split(',');
        
        int[] number = new int[pattern.Length];

        for (int i = 0; i < pattern.Length; i++)
        {
            number[i] = int.Parse(pattern[i]);
        }

        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].GetComponent<Collider>().enabled = true;
            blocks[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < blocks.Length; i++)
        {
            for (int j = 0; j < number.Length; j++)
            {
                if (i == number[j])
                    blocks[i].gameObject.SetActive(true);
            }
        }
    }
}
