using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redChange : MonoBehaviour
{
    public Material emissionMaterial;
    hideObject hideObj;
    GameObject redSwitch;
    GameObject powerBox;
    // Start is called before the first frame update
    void Start()
    {
        redSwitch = GameObject.Find("redSwitch");
        powerBox = GameObject.Find("spanar");
        hideObj = powerBox.GetComponent<hideObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hideObj.isFixed == true)
        {
            redSwitch.GetComponent<MeshRenderer>().material = emissionMaterial;
        }
    }
}
