using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public AudioSource attackSnd;       // attacking sound effect
    private Animator animator;
    Rigidbody rigid;

    [SerializeField] bool isXmoving;        // checks if it is moving "horizontally"

    // x and y speed values
    private float xSpeed;
    private float ySpeed;
    [SerializeField] float speed = 4.0f;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();      // referencing enemy's rigidbody

        // checking for which way i say in the editor to move
        if (isXmoving)
        {
            ySpeed = 0.0f;
            xSpeed = speed;
        }
        else
        {
            xSpeed = 0.0f;
            ySpeed = speed;
        }
    }
    
    void Update()
    {
        rigid.velocity = new Vector3(xSpeed, 0, ySpeed);        // automatically moving with the rigidbody
    }

    // when the enemy hits the invisible enemy bounds it bounces off
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ebounds")
        {
            xSpeed *= -1;
            ySpeed *= -1; 
        }
    }

    // when colliding with the player the enemy attacks and plays attacking sound
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetBool("attack", true);
            attackSnd.PlayOneShot(attackSnd.clip, 1.0f);    // play attacking sound
        }
    }

    // attacking stops when not colliding anymore
    private void OnCollisionExit(Collision collision)
    {
        animator.SetBool("attack", false);
    }
}
