using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPlane : MonoBehaviour
{
    Vector3 originalPosition;
    Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = gameObject.transform.position;
        originalRotation = gameObject.transform.rotation;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "plane")
        {
            gameObject.transform.position = originalPosition;
            gameObject.transform.rotation = originalRotation;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    } 

   
}
