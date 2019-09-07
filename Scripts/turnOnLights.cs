using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class turnOnLights : MonoBehaviour
    {       
        GameObject obj;
        GameObject[] spotlights;
        GameObject glass;
        Throwable throwScript;
        Light flashlight;
        AudioSource audiosource;     
        // Start is called before the first frame update
        void Start()
        {
            obj = GameObject.FindGameObjectWithTag("yellowflashlight");
            spotlights = GameObject.FindGameObjectsWithTag("yellowspotlight");
            glass = GameObject.FindGameObjectWithTag("yellowinsidelight");
            //flashlight = GetComponent<Light>();
            throwScript = obj.GetComponent<Throwable>();
            //flashlight = spotlight.GetComponent<Light>();
            audiosource = GetComponent<AudioSource>();
            foreach (GameObject spotlight in spotlights)
            {
                spotlight.SetActive(true);
            }           
            //flashlight.enabled = false;
            glass.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {          
            //Debug.Log("Attached is: " + throwScript.attached);
            if (throwScript.attached == true)
            {
                //Debug.Log("flashlight is enabled");
                foreach (GameObject spotlight in spotlights)
                {
                    spotlight.SetActive(true);
                }
               // flashlight.enabled = true;
                glass.SetActive(true);
               
            }
            else
            {
                //Debug.Log("flashlight is not enabled");
                foreach (GameObject spotlight in spotlights)
                {
                    spotlight.SetActive(false);
                }
               // flashlight.enabled = false;
                glass.SetActive(false);
                audiosource.Play();
            }
          
        }
    }
}
