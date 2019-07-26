using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float speedLimit = 9f;

    Rigidbody rb;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    float previousAngleOfMovement, wantedAngleOfMovement = 0.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        //Resets player position, for testing only
        if (Input.GetKey(KeyCode.I)&& Input.GetKey(KeyCode.O)&& Input.GetKey(KeyCode.P))
        {
            transform.position = Vector3.zero + Vector3.up;
            rb.velocity = Vector3.zero;
        }

    }
    void FixedUpdate()
    {
        Move();
        
    }
    void Move()
    {
        Vector3 currentVelocity = rb.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(currentVelocity);
        previousAngleOfMovement = Mathf.Acos(currentVelocity.x / currentVelocity.magnitude);
        if (currentVelocity.magnitude < speedLimit)
        {
            rb.AddForce(new Vector3(horizontalMove, 0, verticalMove));
        }
        else if (currentVelocity.magnitude >= speedLimit)
        {
            wantedAngleOfMovement = Mathf.Acos()
            if (true)
            {

            }
        }
        print(currentVelocity + "rb");
        print(localVelocity + "local");
    }
}
