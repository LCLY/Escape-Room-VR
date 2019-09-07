using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class circle2 : MonoBehaviour
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

        public void Achieved2()
        {
            thirdPuzzleScript.secondPiece = true;
            temp.Play();
            //Debug.Log("YEAH2!!!");
        }

        public void soundEffect2()
        {
            thirdPuzzleScript.secondPiece = false;
            temp.Play();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}