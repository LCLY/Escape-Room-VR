using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideObject : MonoBehaviour
{
    public bool isFixed = false;
    GameObject electricBox;
    GameObject spanar;
    GameObject[] sparks;
    public AudioClip successSound;
    public AudioClip ratchet;
    AudioSource success;
    GameObject[] lights;
    GameObject onHandSpanar;
    // Start is called before the first frame update
    void Start()
    {
        electricBox = GameObject.Find("powerbox");
        spanar = GameObject.Find("spanar");
        onHandSpanar = GameObject.Find("onHandSpanar");
        success = spanar.GetComponent<AudioSource>();
        success.clip = ratchet;
        success.Play();
        if (sparks == null)
        {
            sparks = GameObject.FindGameObjectsWithTag("sparks");
        }
        
        if (lights == null)
        {
            lights = GameObject.FindGameObjectsWithTag("lights");
        }
        //disable all lights on start
        foreach (GameObject light in lights)
        {
            light.SetActive(false);
        }

    }
    public void hideTheObject()
    {         
        Debug.Log("HIDE");
        this.gameObject.SetActive(false);      
        onHandSpanar.SetActive(true);
        foreach (GameObject spark in sparks)
        {
            spark.SetActive(false);
        }
        //enable all ights after powerbox is fixed
        foreach (GameObject light in lights)
        {
            light.SetActive(true);
        }

    }

    public void activateSound()
    {
        Debug.Log("PLAY SOUND");
        isFixed = true;
        success.clip = successSound;
        success.Play();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
