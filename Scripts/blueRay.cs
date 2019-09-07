using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem
{
    public class blueRay : MonoBehaviour
    {
        public Material emissionMaterial;
        GameObject obj;
        GameObject blueButton;    
        Throwable throwScript;
        public GameObject TextEnable;
        public GameObject TextDisable;
        public AudioClip buttonEnabled;
        AudioSource tempAS;
        public bool textEnabled = false;
        // Start is called before the first frame update
        void Start()
        {
            obj = GameObject.Find("blueflashlight");
            blueButton = GameObject.Find("blueButton");           
            throwScript = obj.GetComponent<Throwable>();
            tempAS = blueButton.GetComponent<AudioSource>();
            textEnabled = false;
        }


        // Update is called once per frame
        void Update()
        {
            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                if (hit.collider.gameObject.name == "blue")
                {
                    //Debug.Log("collided with blue Button, change material!");
                    blueButton.GetComponent<MeshRenderer>().material = emissionMaterial;
                    textEnabled = true;
                    tempAS.clip = buttonEnabled;
                    tempAS.Play();
                    TextEnable.SetActive(true);
                    TextDisable.SetActive(false);
                    Destroy(this);
                }
                else
                {
                    textEnabled = false;
                }


                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                //Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                //Debug.Log("Did not Hit");
            }
           

        }
    }
}
