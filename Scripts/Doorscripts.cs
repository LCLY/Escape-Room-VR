using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorscripts : MonoBehaviour
{
    private Animator animator;
    private AudioSource asource;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        asource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.enabled)
        {
            this.enabled = false;
            if (other.tag == "Player")
            {
                animator.SetBool("open", true);
                asource.Play();
            }
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
