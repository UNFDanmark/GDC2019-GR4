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
       
        //Resets player position, for testing only
        if (Input.GetKey(KeyCode.I)&& Input.GetKey(KeyCode.O)&& Input.GetKey(KeyCode.P))
        {
            transform.position = Vector3.zero + Vector3.up*1.1f;
            rb.velocity = Vector3.zero;
            fuelConsume.currentFuel = fuelConsume.maximumFuel;
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

        float angleBetweenRotations = Vector3.Angle(transform.forward, rb.velocity);
        if (angleBetweenRotations > 180)
        {
            angleBetweenRotations = -180 + (angleBetweenRotations - 180);
            print(angleBetweenRotations);
        }
        transform.Rotate(Vector3.up, angleBetweenRotations * Time.fixedDeltaTime * rotateSpeed);

        if (wantToMove == true)
        {
            Move();
            previousVelocity = rb.velocity;
        }

        
    }
    void Move()
    {

        //uses currentforce counter to make a max movement speed
        if (rb.velocity.magnitude >= maxSpeed)
        {
            rb.velocity = previousVelocity;
        }
        else
        {
            rb.AddForce(new Vector3(horizontalMove, 0, verticalMove));
        }
        
        

        if (wantToMove == true)
        {
            fuelConsume.ConsumeFuel();
        }
    }
}
