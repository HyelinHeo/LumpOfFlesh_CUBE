using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rbs = GetComponentsInChildren<Rigidbody>();
        foreach (var item in rbs)
        {
            item.AddExplosionForce(10.0f, transform.position, 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
