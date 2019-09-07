using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenChange : MonoBehaviour
{
    public Material emissionMaterial;
    hideObject hideObj;
    GameObject greenSwitch;
    GameObject powerBox;
    // Start is called before the first frame update
    void Start()
    {
        greenSwitch = GameObject.Find("greenSwitch");
        powerBox = GameObject.Find("spanar");
        hideObj = powerBox.GetComponent<hideObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //isFixed from hideObject
        if (hideObj.isFixed == true)
        {
            //change the material to bright when isFixed is true
            greenSwitch.GetComponent<MeshRenderer>().material = emissionMaterial;
        }
    }
}
