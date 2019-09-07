using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem
{
    public class fixscript : MonoBehaviour
    {
        Throwable throwScript;
        Animator anim;
        GameObject spanar;
        GameObject onHandSpanar;
        AudioSource spanarSound;
        // Start is called before the first frame update
        void Start()
        {
            onHandSpanar = GameObject.Find("onHandSpanar");
            spanar = GameObject.Find("spanar");
            spanar.SetActive(false);
            spanarSound = spanar.GetComponent<AudioSource>();
            anim = spanar.GetComponent<Animator>();
            throwScript = onHandSpanar.GetComponent<Throwable>();
        }

        // Destroy everything that enters the trigger
        void OnTriggerEnter(Collider other)
        {
            if (this.enabled)
            {
                this.enabled = false;
                //This will fire only the first time this object hits a trigger
                if (other.tag == "spanar")
                {
                    spanar.SetActive(true);
                    onHandSpanar.SetActive(false);
                    spanarSound.Play();
                    throwScript.attached = false;
                    throwScript.onDetachFromHand.Invoke(); //have to invoke this                           
                    anim.SetTrigger("isFixing");
                    Debug.Log("FIXED");
                }
            }
          
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}