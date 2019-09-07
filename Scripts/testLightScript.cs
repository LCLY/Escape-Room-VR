using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLightScript : MonoBehaviour
{
    bool reset = false;
    static string passcode = "312";
    static string playercode = "";
    static int totalDigits = 0;
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
    
    // Start is called before the first frame update
    void Start()
    {
        temp1 = light1.GetComponent<Light>();
        temp2 = light2.GetComponent<Light>();
        temp3 = light3.GetComponent<Light>();
        eyeTemp1 = eye1.GetComponent<Light>();
        eyeTemp2 = eye2.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (totalDigits >= 3)
        {
            if (playercode == passcode)
            {
                eyeTemp1.color = Color.green;
                eyeTemp2.color = Color.green;
                playercode = "";
                totalDigits = 0;              
                Debug.Log("Correct!");
            }
            else
            {
                eyeTemp1.color = Color.red;
                eyeTemp2.color = Color.red;
                playercode = "";               
                totalDigits = 0;
                reset = false;               
                Debug.Log("Incorrect!");
            }

        }


        if (Input.GetKeyDown(KeyCode.Keypad1))
        {           
            Debug.Log("1 key was pressed");
            playercode += "1";
            Debug.Log("Playercode: " + playercode);
            //if right now is the first number then change the first light bulb
            //YELLOW BUTTON
            if (totalDigits == 0)
            {              
                temp1.color = Color.yellow;
            }
            //if right now is the second number then change the second light bulb
            else if (totalDigits == 1)
            {            
                temp2.color = Color.yellow;
            }
            else if (totalDigits == 2)
            {               
                temp3.color = Color.yellow;
            }
            totalDigits++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {          
            //RED BUTTON
            Debug.Log("2 key was pressed");
            playercode += "2";
            Debug.Log("Playercode: " + playercode);
            if (totalDigits == 0)
            {                
                temp1.color = Color.red;
            }
            //if right now is the second number then change the second light bulb
            else if (totalDigits == 1)
            {             
                temp2.color = Color.red;
            }
            else if (totalDigits == 2)
            {              
                temp3.color = Color.red;
            }
            totalDigits++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            //BLUE BUTTON
            Debug.Log("3 key was pressed");
            playercode += "3";
            Debug.Log("Playercode: " + playercode);
            if (totalDigits == 0)
            {               
                temp1.color = Color.blue;
            }
            //if right now is the second number then change the second light bulb
            else if (totalDigits == 1)
            {              
                temp2.color = Color.blue;
            }
            else if (totalDigits == 2)
            {              
                temp3.color = Color.blue;
            }
            totalDigits++;
        }
     
    }
}            