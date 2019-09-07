using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem
{ 
    public class clickButton : MonoBehaviour
    {
        //THIS SCRIPT IS IN THE GAMEOBJECT NAME "Collider"         
        static string passcode = "312";
        static string playercode = "";
        static int totalDigits = 0;
        bool reset = false;
        public AudioClip correct;
        public AudioClip wrong;
        AudioSource asource;         
        public GameObject light1;
        public GameObject light2;
        public GameObject light3;
        public GameObject eye1;
        public GameObject eye2;       
        Light temp1;
        Light temp2;
        Light temp3;
        Light eyeTemp1;
        Light eyeTemp2;
        public AudioClip buttonClick;
        bool clickedYellow = false;
        bool clickedRed = false;
        bool clickedBlue = false;
        Color currentColor1;
        Color currentColor2;
        Color currentColor3;
        float duration = 10f;

        //getting scripts
        GameObject yr;
        GameObject br;
        GameObject rr;
        yellowRay yellowScript;
        redRay redScript;
        blueRay blueScript;

        //getting the opening poster
        GameObject open;
        Animator openAnim;
        AudioSource openAudio;

        //for turning on the light
        public Material emissionMaterial;
        GameObject[] posterLights;
        GameObject posterLamp;
        public GameObject posterlight1;
        public GameObject posterlight2;     

        // Start is called before the first frame update
        void Start()
        {         
            //this is for changing the lights
            temp1 = light1.GetComponent<Light>();
            temp2 = light2.GetComponent<Light>();
            temp3 = light3.GetComponent<Light>();
            eyeTemp1 = eye1.GetComponent<Light>();
            eyeTemp2 = eye2.GetComponent<Light>();

            //this is for getting the script from yellow/red/blue ray
            yr = GameObject.Find("yellowray");
            br = GameObject.Find("blueray");
            rr = GameObject.Find("redray");
            yellowScript = yr.GetComponent<yellowRay>();
            redScript = rr.GetComponent<redRay>();
            blueScript = br.GetComponent<blueRay>();

            //this is for the opening the poster
            open = GameObject.FindGameObjectWithTag("open");
            openAnim = open.GetComponent<Animator>();
            openAudio = open.GetComponent<AudioSource>();
            posterLamp = GameObject.Find("DOFA_900_M_000");           
            posterlight1.SetActive(false);
            posterlight2.SetActive(false);
        }


        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("yellowButton"))
            {                      
                    clickedYellow = true;             
            }
            else if (other.gameObject.CompareTag("blueButton"))
            {               
                    clickedBlue = true;              
            }
            else if (other.gameObject.CompareTag("redButton"))
            {              
                    clickedRed = true;               
            }

        }

         
        

        void Update()
        {
            Debug.Log("the Total digits is: " + totalDigits);  
            if (totalDigits >= 3)
                {
                    if (playercode == passcode)
                    {                       
                        GameObject lightbase = GameObject.Find("lightbulbbase");
                        asource = lightbase.GetComponent<AudioSource>();
                        eyeTemp1.color = Color.green;
                        eyeTemp2.color = Color.green;
                        asource.clip = correct;                      
                        playercode = "";
                        totalDigits = 0;                       
                        asource.Play();                     
                        openAnim.SetTrigger("Open");
                        //enable all ights after powerbox is fixed
                        posterlight1.SetActive(true);
                        posterlight2.SetActive(true);
                        posterLamp.GetComponent<MeshRenderer>().material = emissionMaterial;
                        openAudio.Play();
                        Debug.Log("Correct!");                        
                    }
                    else
                    {
                        GameObject lightbase = GameObject.Find("lightbulbbase");
                        asource = lightbase.GetComponent<AudioSource>();
                        eyeTemp1.color = Color.red;
                        eyeTemp2.color = Color.red;                                            
                        temp1.color = Color.white;
                        temp2.color = Color.white;
                        temp3.color = Color.white;
                        asource.clip = wrong;
                        playercode = "";                        
                        totalDigits = 0;
                        reset = false;
                        asource.Play();
                        Debug.Log("Incorrect!");
                  }
                
                }

            if (yellowScript.textEnabled == true && clickedYellow == true)
            {
                GameObject yellowButton = GameObject.Find("yellowButton");
                AudioSource asource = yellowButton.GetComponent<AudioSource>();
                asource.clip = buttonClick;
                asource.Play();
                Debug.Log("Clicked YELLOW button!");
                playercode += "1";
                //YELLOW BUTTON
                if (totalDigits == 0)
                {
                    temp1.color = Color.yellow;                
                    currentColor1 = temp1.color;
                }
                //if right now is the second number then change the second light bulb
                else if (totalDigits == 1)
                {
                    temp2.color = Color.yellow;
                    currentColor2 = temp1.color;
                }
                else if (totalDigits == 2)
                {
                    temp3.color = Color.yellow;
                    currentColor3 = temp1.color;
                }
                Debug.Log("playercode:" + playercode);
                totalDigits++;
                clickedYellow = false; //reset the bool value
            }
            else if (blueScript.textEnabled == true && clickedBlue == true)
            {
                GameObject blueButton = GameObject.Find("blueButton");
                AudioSource asource = blueButton.GetComponent<AudioSource>();
                asource.clip = buttonClick;
                asource.Play();
                Debug.Log("Clicked BLUE button!");
                playercode += "3";
                //BLUE BUTTON
                if (totalDigits == 0)
                {
                    temp1.color = Color.blue;
                    currentColor1 = temp1.color;
                }
                //if right now is the second number then change the second light bulb
                else if (totalDigits == 1)
                {
                    temp2.color = Color.blue;
                    currentColor2 = temp2.color;
                }
                else if (totalDigits == 2)
                {
                    temp3.color = Color.blue;
                    currentColor3 = temp3.color;
                }
                Debug.Log("playercode:" + playercode);
                totalDigits++;
                clickedBlue = false; //reset the bool value
            }
            else if (redScript.textEnabled == true && clickedRed == true)
            {
                GameObject redButton = GameObject.Find("redButton");
                AudioSource asource = redButton.GetComponent<AudioSource>();
                asource.clip = buttonClick;
                asource.Play();
                Debug.Log("Clicked RED button!");
                playercode += "2";
                //RED BUTTON
                if (totalDigits == 0)
                {
                    temp1.color = Color.red;
                    currentColor1 = temp1.color;
                }
                //if right now is the second number then change the second light bulb
                else if (totalDigits == 1)
                {
                    temp2.color = Color.red;
                    currentColor2 = temp2.color;
                }
                else if (totalDigits == 2)
                {
                    temp3.color = Color.red;
                    currentColor3 = temp3.color;
                }
                Debug.Log("playercode:" + playercode);
                totalDigits++;
                clickedRed = false;//reset the bool value            
        }



        }
    }
}
