using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
    public class testscript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.name == "yellowButton")
            {
                Debug.Log("DETECTED!");
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}