using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject breakCube;
    private Transform breakCubeParent;

    // Start is called before the first frame update
    void Start()
    {
        breakCubeParent = GameObject.Find("BreakBlock").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            GetComponent<Collider>().enabled = false;
            GameObject objBreak = Instantiate(breakCube, transform.position, Quaternion.identity, breakCubeParent);
            Destroy(objBreak, 5f);
            gameObject.SetActive(false);
        }
    }
}
