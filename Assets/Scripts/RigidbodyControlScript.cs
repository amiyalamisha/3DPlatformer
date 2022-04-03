using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyControlScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float speed;


    [SerializeField] private Vector3 newCenterOfMass;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        
    }

    void Update()
    {
        rb.AddTorque(Vector3.up * turnSpeed * Input.GetAxis("Horizontal")); // Add rotation.
        rb.AddRelativeForce(new Vector3(0.0f, 0.0f, speed * Input.GetAxis("Vertical"))); // Add force in direction of movement.
        rb.centerOfMass = newCenterOfMass;
    }

}




