using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class circle1 : MonoBehaviour
    {
        public GameObject reference;
        public GameObject asource;
        AudioSource temp;
        ThirdPuzzle thirdPuzzleScript;
        // Start is called before the first frame update
        void Start()
        {
            thirdPuzzleScript = reference.GetComponent<ThirdPuzzle>();
            temp = asource.GetComponent<AudioSource>();
        }

        public void Achieved1()
        {
            temp.Play();
            thirdPuzzleScript.firstPiece = true;
            //Debug.Log("YEAH1!!!");
        }

        public void soundEffect1()
        {
            thirdPuzzleScript.firstPiece = false;
            temp.Play();
        }

        // Update is called once per frame
        void Update()
        {
          
        }
    }
}
