using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxMovementSpeed;
    public float movementAcceleration;
    public float rotationSpeed;

    public Rigidbody2D rb;

    float xAxis, yAxis;

    private bool isDrifting = false;


    // Update is called once per frame
    void Update()
    {
        yAxis = Input.GetAxisRaw("Vertical");
        xAxis = Input.GetAxisRaw("Horizontal");
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isDrifting = true;
            rb.drag = 0;
        }
        else
        {
            isDrifting = false;
            rb.drag = 2;
        }
    }

    void FixedUpdate() {
        if(!isDrifting)
        {
            if(yAxis > 0)
                rb.velocity = (transform.up * maxMovementSpeed * yAxis);
            rb.AddTorque(xAxis * -rotationSpeed);
        }
    }
}
