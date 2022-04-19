using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Make a 3D game. 
Design a level with lots of platforms and obstacles. Add a player character with a controller based on a rigidbody, 
a character controller, or even a wheel collider. It must be able to move and jump (no need for wheel colliders to jump).
Add enemies with simple movement that have an effect when they collide with the player.
Use free assets from the Unity asset store or the internet to make your level look good. Credit them in a text file
“Credits.txt” in the root of your submitted project.
Use Git. Submit a link to your Git repository.

Grading

D: Create an object with a rigidbody or character controller or wheel collider that can move around an area containing obstacles.

C: The level has a large, interesting and fun layout, with cool obstacles. 

B: The controller is responsive and feels “good.” 

A: There are enemies in the level which move. They produce a visible effect when colliding with the player.
 * */

public class CharacterControllerMove : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;

    // Set in Editor
    [SerializeField] float speed = 6.0f;
    [SerializeField] float gravity = 20.0f;
    [SerializeField] float jumpSpeed = 8.0f;

    // Others
    private Vector3 moveDirection = Vector3.zero;

    // Controls
    private float xMove;
    private float yMove;
    private bool jump;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        animator.SetBool("Grounded", controller.isGrounded);        // checking if the player is on the ground

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(xMove, 0.0f, yMove);
            moveDirection *= speed;


            // Face in dir of move
            if (moveDirection.magnitude > float.Epsilon)
            {
                transform.rotation = Quaternion.LookRotation(moveDirection);
            }

            animator.SetFloat("MoveSpeed", moveDirection.magnitude);

            if (jump)
            {
                moveDirection.y = jumpSpeed;
            }

        }

        // Apply gravity
        moveDirection.y -= gravity * Time.fixedDeltaTime;

        controller.Move(moveDirection * Time.fixedDeltaTime);
    }

    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");
        jump = Input.GetButton("Jump");
    }
}
