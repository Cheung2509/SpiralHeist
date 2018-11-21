using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [HideInInspector]
    public WheelCollider frontL, frontR, rearL, rearR;
    [HideInInspector]
    public Transform t_frontL, t_frontR, t_rearL, t_rearR;

    public float speed, maxRotation, brakeForce, carVelocity;
    private float horizontal, vertical, steeringAngle;

    private void FixedUpdate ()
    {
        GetInput();
        Steer();
        Accelerate();
        WheelPoses();
        Brakes();
	}

    private void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void Accelerate()
    {
        rearL.motorTorque = vertical * speed;
        rearR.motorTorque = vertical * speed;

        // Car's world space velocity
        // Use to clamp speed?
        carVelocity = Vector3.Dot(GetComponent<Rigidbody>().velocity, transform.forward);
        carVelocity = Mathf.Abs(carVelocity);
    }

    private void Steer()
    {
        steeringAngle = maxRotation * horizontal;
        frontL.steerAngle = steeringAngle;
        frontR.steerAngle = steeringAngle;
    }

    private void Brakes()
    // Slows down the car using spacebar.
    // Needs work - not slowing down quick enough (at high speed).
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rearR.brakeTorque = (brakeForce * 100000);
            rearL.brakeTorque = (brakeForce * 100000);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rearR.brakeTorque = 0;
            rearL.brakeTorque = 0;
        }

        if (vertical == 0)
        {
            rearR.brakeTorque = (brakeForce * 10000);
            rearL.brakeTorque = (brakeForce * 10000);
        }
        else
        {
            rearR.brakeTorque = 0;
            rearL.brakeTorque = 0;
        }
    }

    private void WheelPoses()
    // Assigns the wheels colliders and transforms to be rotated.
    {
        UpdateWheelPose(frontL, t_frontL);
        UpdateWheelPose(frontR, t_frontR);
        UpdateWheelPose(rearR, t_rearR);
        UpdateWheelPose(rearL, t_rearL);
    }

    private void UpdateWheelPose(WheelCollider collider, Transform transform)
    // Rotates the wheels when the car moves.
    {
        Vector3 pos = transform.position;
        Quaternion quat = transform.rotation;

        collider.GetWorldPose(out pos, out quat);

        transform.position = pos;
        transform.rotation = quat;
    }
}
