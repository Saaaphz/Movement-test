using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class PlayerController : MonoBehaviour 

{
    public Vector3 jump;
    public float jumpForce = 2.0f;

    bool isGrounded()
    {
        float GroundedDistance = 1f;
        rb = GetComponent<Rigidbody>();
        return Physics.SphereCast(transform.position, 0.5f, Vector3.down, out RaycastHit hit, GroundedDistance);
    }

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && (isGrounded())){

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
    }
}