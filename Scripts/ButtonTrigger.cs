using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonTrigger : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("button"))
        {
            Debug.Log("Clicked button!");
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
