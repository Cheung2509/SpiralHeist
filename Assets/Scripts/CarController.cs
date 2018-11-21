using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject rot;

    public float maxSpeed = 0.0f;
    public float acceleration = 0.0f;
    public float maxRotateSpeed = 0.0f;
    public float rotation = 0.0f;
    
    private float actualAcceleration = 0.0f;
    private float actualRotation = 0.0f;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();        
	}
	
	void Update ()
    {
        float v = Vector3.Dot(rb.velocity.normalized, transform.forward);
                          
        #region linear

        if (Input.GetKey("w"))
        {
            // if not acceleration fastest
            if (actualAcceleration < maxSpeed)
            {
                // speed up
                actualAcceleration += acceleration;
            }
        }
        else if (Input.GetKey("s"))
        {
            // if not acceleration fastest
            if (actualAcceleration > -maxSpeed)
            {
                // speed up
                actualAcceleration -= acceleration;
            }
        }
        else
        {
            // if moving
            if (actualAcceleration > 0.1f || actualAcceleration < -0.1f)
            {
                // slow down
                actualAcceleration *= 0.9f;
            }
            else
            {
                actualAcceleration = 0.0f;
            }
        }

        #endregion

        #region angular

        // if intending to turn left
        if (Input.GetKey("a"))
        {
            if (actualRotation < maxRotateSpeed)
            {
                actualRotation += rotation;
            }
        }

        // if intending to turn right
        if (Input.GetKey("d"))
        {
            if (actualRotation > -maxRotateSpeed)
            {
                actualRotation -= rotation;
            }
        }

        // if not rotating
        if (!(Input.GetKey("a")) && !(Input.GetKey("d")))
        {
            if (actualRotation > 0.1f)
            {
                actualRotation -= rotation;
            }
            else if(actualRotation < -0.1f)
            {
                actualRotation += rotation;
            }
            else
            {
                actualRotation = 0.0f;
            }
        }

        #endregion
        
        // if under speed limit
        if ((rb.velocity.x < maxSpeed && rb.velocity.x > -maxSpeed) && (rb.velocity.z < maxSpeed && rb.velocity.z > -maxSpeed))
        {
            // if above minimum threshold
            if (Mathf.Abs(actualAcceleration) > 0.1f)
            {
                // apply linear motion
                rb.velocity += (transform.forward * actualAcceleration);
            }
        }

        // if right
        if (actualRotation > 0.1f)
        {
            // apply angular motion
            transform.rotation = Quaternion.RotateTowards(rb.rotation, rot.transform.rotation, actualRotation);
        }
        // if left
        else if (actualRotation < -0.1f)
        {
            // apply angular motion
            transform.rotation = Quaternion.RotateTowards(rb.rotation, rot.transform.rotation, actualRotation);
        }
    }     
}