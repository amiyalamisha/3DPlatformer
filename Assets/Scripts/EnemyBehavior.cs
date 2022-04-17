using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
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

    private void FixedUpdate()
    {/*
        moveDirection = new Vector3(xSpeed, 0.0f, ySpeed);
        moveDirection *= speed;
        transform.position = moveDirection;
        */
        // Apply gravity
        //moveDirection.y -= gravity * Time.fixedDeltaTime;
    }
    
    void Update()
    {
        /*
        moveDirection = new Vector3(xSpeed, 0.0f, ySpeed);
        moveDirection *= speed;
        transform.position = moveDirection;
        */

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
}
