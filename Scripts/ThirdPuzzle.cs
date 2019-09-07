using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class ThirdPuzzle : MonoBehaviour
    {
        public GameObject supplyBox;
        public bool firstPiece;
        public bool secondPiece;
        public bool thirdPiece;
        public bool forthPiece;
        Animator animTemp;
        AudioSource asource;
        GameObject boxSupply;
        // Start is called before the first frame update
        void Start()
        {
            boxSupply = GameObject.Find("box_supply");
            animTemp = supplyBox.GetComponent<Animator>();
            asource = boxSupply.GetComponent<AudioSource>();
            firstPiece = false;
            secondPiece = false;
            thirdPiece = false;
            forthPiece = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (firstPiece == true && secondPiece == true && thirdPiece == true && forthPiece == true)
            {
                asource.Play();
                animTemp.SetBool("Complete", true);
                //Debug.Log("ALL TRUE");
                firstPiece = false;
                secondPiece = false;
                thirdPiece = false;
                forthPiece = false;
            }
        }
    }
}