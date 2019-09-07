using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem
{
    public class yellowRay : MonoBehaviour
    {
        public Material emissionMaterial;
        GameObject obj;      
        GameObject yellowButton;
        Throwable throwScript;
        public GameObject TextEnable;
        public GameObject TextDisable;
        public AudioClip buttonEnabled;
        AudioSource tempAS;
        public bool textEnabled = false;
        // Start is called before the first frame update
        void Start()
        {
            obj = GameObject.Find("yellowflashlight");           
            yellowButton = GameObject.Find("yellowButton");
            throwScript = obj.GetComponent<Throwable>();
            tempAS = yellowButton.GetComponent<AudioSource>();
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
                if (hit.collider.gameObject.name == "yellow")
                {
                    //Debug.Log("collided with yellowButton, change material!");
                    yellowButton.GetComponent<MeshRenderer>().material = emissionMaterial;
                    tempAS.clip = buttonEnabled;
                    tempAS.Play();
                    textEnabled = true;
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
