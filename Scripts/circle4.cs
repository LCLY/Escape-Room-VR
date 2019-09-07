using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class circle4 : MonoBehaviour
    {
        public GameObject reference;
        public GameObject asource;
        ThirdPuzzle thirdPuzzleScript;
        AudioSource temp;
        // Start is called before the first frame update
        void Start()
        {
            thirdPuzzleScript = reference.GetComponent<ThirdPuzzle>();
            temp = asource.GetComponent<AudioSource>();
        }

        public void Achieved4()
        {
            thirdPuzzleScript.forthPiece = true;
            temp.Play();
            //Debug.Log("YEAH4!!!");
        }

        public void soundEffect4()
        {
            thirdPuzzleScript.forthPiece = false;
            temp.Play();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
