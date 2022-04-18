using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public AudioSource attackSnd;
    private Animator animator;
    Rigidbody rigid;

    [SerializeField] float speed = 4.0f;
    [SerializeField] bool isXmoving;        // checks if it is moving "horizontally"

    private Vector3 moveDirection = Vector3.zero;

    // x and y speed values
    private float xSpeed = 4.0f;
    private float ySpeed = 4.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();      // referencing enemy's rigidbody

        // checking for which way i say in the editor to move
        if (isXmoving)
        {
            ySpeed = 0.0f;
        }
        else
        {
            xSpeed = 0.0f;
        }
    }
    
    void Update()
    {
        rigid.velocity = new Vector3(xSpeed, 0, ySpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ebounds")
        {
            //speed *= -1;
            xSpeed *= -1;
            ySpeed *= -1;

            if(speed < 0)
            {
                animator.SetBool("reverse", true);
            }
            else
            {
                animator.SetBool("reverse", false);
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetBool("attack", true);
            attackSnd.PlayOneShot(attackSnd.clip, 1.0f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        animator.SetBool("attack", false);
    }
}
