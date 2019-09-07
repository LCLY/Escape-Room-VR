using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class circle3 : MonoBehaviour
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

        public void Achieved3()
        {
            thirdPuzzleScript.thirdPiece = true;
            temp.Play();
            //Debug.Log("YEAH3!!!");
        }

        public void soundEffect3()
        {
            thirdPuzzleScript.thirdPiece = false;
            temp.Play();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}