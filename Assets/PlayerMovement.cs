using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxMovementSpeed;
    public float movementAcceleration;
    public float movementDeacceleration;

    public float maxRotationSpeed;
    public float maxRotationSpeedDrifting;
    public float rotationAcceleration;
    public float rotationDeacceleration;

    public float normalHandling;
    public float driftHandling;

    private float currentMovementSpeed;
    private float currentRotationSpeed;

    public ParticleSystem driftParticles;
    public ParticleSystem boostParticles;


    public Rigidbody2D rb;

    float xAxis, yAxis;

    private bool isDrifting = false;


    // Update is called once per frame
    void Update()
    {
        float prevYAxis = yAxis;
        yAxis = Input.GetAxisRaw("Vertical");
        xAxis = Input.GetAxisRaw("Horizontal");
        //Instant directional change
        if(prevYAxis == 0 && yAxis > 0)
        {
            rb.velocity = transform.up * 1f;
            boostParticles.Play();
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isDrifting = true;
            driftParticles.Play();
        }
        else
        {
            isDrifting = false;
            driftParticles.Stop();
        }

    }

    void FixedUpdate() {
        if(!isDrifting)
        {
            if (yAxis > 0)
            {
                currentMovementSpeed += movementAcceleration * Time.fixedDeltaTime;
            }
            else
            {
                currentMovementSpeed -= movementDeacceleration * Time.fixedDeltaTime;
            }
            currentMovementSpeed = Mathf.Clamp(currentMovementSpeed, 0, maxMovementSpeed);
            float velAngle = Mathf.Rad2Deg * Mathf.Atan2(rb.velocity.y, rb.velocity.x);
            float deltaAngle = Mathf.DeltaAngle(velAngle, transform.rotation.eulerAngles.z);
            float newVelAngle = Mathf.Lerp(velAngle, velAngle + deltaAngle + 90f, normalHandling * Time.fixedDeltaTime);
            rb.velocity = Quaternion.Euler(0, 0, newVelAngle) * Vector3.right * currentMovementSpeed;
            Rotation(maxRotationSpeed);
        }
        else
        {
            Rotation(maxRotationSpeedDrifting);
            float velAngle = Mathf.Rad2Deg*Mathf.Atan2(rb.velocity.y, rb.velocity.x);
            float deltaAngle = Mathf.DeltaAngle(velAngle, transform.rotation.eulerAngles.z);
            float newVelAngle = Mathf.Lerp(velAngle, velAngle + deltaAngle + 90f, driftHandling * Time.fixedDeltaTime);
            rb.velocity = Quaternion.Euler(0, 0, newVelAngle) * Vector3.right * currentMovementSpeed;
        }

        transform.Rotate(new Vector3(0, 0, currentRotationSpeed * Time.fixedDeltaTime));
    }

    private void Rotation(float speed)
    {
        if (xAxis != 0)
        {
            currentRotationSpeed -= xAxis * rotationAcceleration * Time.fixedDeltaTime;
            currentRotationSpeed = Mathf.Clamp(currentRotationSpeed, -speed, speed);
        }
        else
        {
            if (rotationDeacceleration * Time.fixedDeltaTime > Mathf.Abs(currentRotationSpeed))
            {
                currentRotationSpeed = 0;
            }
            else
            {
                currentRotationSpeed -= Mathf.Sign(currentRotationSpeed) * rotationDeacceleration * Time.fixedDeltaTime;
            }
        }
    }
}
