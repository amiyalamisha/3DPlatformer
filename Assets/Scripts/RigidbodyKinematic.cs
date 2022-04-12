using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyKinematic : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float speed;


    private float rotate;
    private float forward;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (transform.forward * speed * forward * Time.fixedDeltaTime));
        rb.MoveRotation(Quaternion.AngleAxis(rotate * turnSpeed, Vector3.up) * rb.rotation);
    }

    void Update()
    {
        /*rb.AddTorque(Vector3.up * turnSpeed * Input.GetAxis("Horizontal")); // Add rotation.
        rb.AddRelativeForce(new Vector3(0.0f, 0.0f, speed * Input.GetAxis("Vertical"))); // Add force in direction of movement.*/
        rotate = Input.GetAxis("Horizontal");
        forward = Input.GetAxis("Vertical");

    }
}
