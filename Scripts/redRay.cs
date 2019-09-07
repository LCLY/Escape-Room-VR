using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem
{
    public class redRay : MonoBehaviour
    {
        public Material emissionMaterial;
        GameObject obj;
        GameObject redButton;       
        Throwable throwScript;
        public GameObject TextEnable;
        public GameObject TextDisable;
        public AudioClip buttonEnabled;
        public bool textEnabled = false;
        AudioSource tempAS;
        // Start is called before the first frame update
        void Start()
        {
            obj = GameObject.Find("redflashlight");            
            redButton = GameObject.Find("redButton");
            throwScript = obj.GetComponent<Throwable>();
            tempAS = redButton.GetComponent<AudioSource>();
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
                if (hit.collider.gameObject.name == "red")
                {
                    //Debug.Log("collided with red button, change material!");
                    redButton.GetComponent<MeshRenderer>().material = emissionMaterial;
                    tempAS.clip = buttonEnabled;
                    tempAS.Play();
                    TextEnable.SetActive(true);
                    TextDisable.SetActive(false);
                    textEnabled = true;
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
