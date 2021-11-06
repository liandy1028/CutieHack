using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public Rigidbody2D rb;

    float xAxis, yAxis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yAxis = Input.GetAxisRaw("Vertical");
        xAxis = Input.GetAxisRaw("Horizontal");
        

    }

    void FixedUpdate() {
        rb.AddForce(transform.up * movementSpeed * yAxis);
        rb.AddTorque(-rotationSpeed * xAxis);
    }
}
