using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveForce = 1f;
    public float maxSpeed = 5;
    public float rotateSpeed = 2f;

    Rigidbody rb;
    FuelConsumptionScript fuelConsume;
    public AudioSource source;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    Vector3 previousAngleOfVelocity;
    Vector3 desiredAngle;
    bool wantToMove = false;
    Vector3 previousVelocity = new Vector3(0, 0, 0);
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fuelConsume = GetComponent<FuelConsumptionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(rb.velocity.x, 0, rb.velocity.z));

        if (wantToMove)
        {
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
        else
        {
            source.Stop();
        }
    }

    void FixedUpdate()
    {
        horizontalMove = Input.GetAxis("Horizontal") * moveForce;
        verticalMove = Input.GetAxis("Vertical") * moveForce;

        
        if (horizontalMove != 0 || verticalMove != 0)
        {
            wantToMove = true;
        }
        else
        {
            wantToMove = false;
        }

        if (wantToMove)
        {
            previousVelocity = rb.velocity;
            Move();
        }



    }
    void Move()
    {
        rb.AddForce(new Vector3(horizontalMove, 0, verticalMove));
        
        //uses currentforce counter to make a max movement speed
        if (rb.velocity.magnitude >= maxSpeed)
        {
            rb.velocity = previousVelocity;         
        }
            fuelConsume.ConsumeFuel();
    }
}
