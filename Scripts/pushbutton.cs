using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushbutton : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update

    void Start()
    {
        animator = GetComponent<Animator>();
        //asource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {

        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if (collision.relativeVelocity.magnitude > 1)
        {
            Debug.Log("COLLIDED!");
            animator.SetTrigger("New Trigger");
           // animator.SetBool("Click", false);
        }
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
