using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightflicker : MonoBehaviour
{
    Light testLight;
    hideObject hideObj;
    public float minWaitTime;
    public float maxWaitTime;
    public GameObject reference;
    GameObject lightbulb;
    AudioSource asource;
    void Start()
    {
        lightbulb = GameObject.Find("Ampoule");
        hideObj = reference.GetComponent<hideObject>();
        testLight = GetComponent<Light>();
        StartCoroutine(Flashing());
        asource = lightbulb.GetComponent<AudioSource>(); 
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            testLight.enabled = !testLight.enabled;
            if(hideObj.isFixed == true)
            {
                asource.Stop();
                testLight.enabled = true;
                break;
            }
        }
    }
}

