using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Animator animator;

    [SerializeField] float speed = 4.0f;
    [SerializeField] float gravity = 20.0f;
    [SerializeField] bool isXmoving;

    private Vector3 moveDirection = Vector3.zero;

    private float xSpeed;
    private float ySpeed;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (isXmoving)
        {
            ySpeed = 0;
        }
        else
        {
            xSpeed = 0;
        }
    }

    private void FixedUpdate()
    {
        moveDirection = new Vector3(xSpeed, 0.0f, ySpeed);
        moveDirection *= speed;
        transform.position = moveDirection;

        // Apply gravity
        moveDirection.y -= gravity * Time.fixedDeltaTime;
    }
    
    void Update()
    {
        /*
        moveDirection = new Vector3(xSpeed, 0.0f, ySpeed);
        moveDirection *= speed;
        transform.position = moveDirection;
        */

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ebounds")
        {
            speed *= -1;
        }
    }
}
