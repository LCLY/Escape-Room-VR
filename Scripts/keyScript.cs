using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class keyScript : MonoBehaviour
    {
        Throwable throwScript;
        public GameObject realkey;
        public GameObject fakekey;
        public GameObject door;
        public GameObject happySong;
        public GameObject scarySong;
        public GameObject timerObj;
        Animator dooranim;
        AudioSource asource;
        AudioSource happySource;
        AudioSource scarySource;
        AudioSource timerSource;
        public GameObject tp2;
        public GameObject cheering;
        Vector3 originalPosition;
        // Start is called before the first frame update

        void Awake()
        {
            tp2.SetActive(false);
            originalPosition = realkey.transform.position;
        }

        void Start()
        {           
            cheering.SetActive(false);
            fakekey.SetActive(false);         
            dooranim = door.GetComponent<Animator>();
            asource = door.GetComponent<AudioSource>();
            throwScript = realkey.GetComponent<Throwable>();
            happySource = happySong.GetComponent<AudioSource>();
            scarySource = scarySong.GetComponent<AudioSource>();
            timerSource = timerObj.GetComponent<AudioSource>();                      
           
        }

        void OnTriggerEnter(Collider other)
        {           
            if (other.gameObject.CompareTag("key"))
            {
                Debug.Log("THE KEY IS COLLIDING!");
                fakekey.SetActive(true);
                realkey.SetActive(false);
                throwScript.attached = false;
                throwScript.onDetachFromHand.Invoke(); //have to invoke this
                StartCoroutine(Example());             
                //realkey.SetActive(false);
                asource.Play();
                dooranim.SetBool("open", true);              
                scarySource.Stop();
                timerSource.Stop();
                happySource.Play();                   
                cheering.SetActive(true);
                tp2.SetActive(true);
            }
        }
        IEnumerator Example()
        {           
            yield return new WaitForSeconds(3);
            fakekey.SetActive(false);
            realkey.SetActive(true);
            realkey.transform.position = originalPosition;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
