using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyEventScript : MonoBehaviour
{
    public GameObject fakekey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void releaseTheKey()
    {
        fakekey.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
