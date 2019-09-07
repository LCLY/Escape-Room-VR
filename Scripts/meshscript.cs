using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshscript : MonoBehaviour
{
    GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find("Etagere");
    }

    // Update is called once per frame
    void Update()
    {
        var c = go.AddComponent<NonConvexMeshCollider>();
        c.Calculate();
    }
}
