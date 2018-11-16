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

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();        
	}
	
	// Update is called once per frame
	void Update ()
    {
        #region linear

        // if holding forward
        if (Input.GetKey("w"))
        {
            // if not acceleration fastest
            if (actualAcceleration < maxSpeed)
            {
                // speed up
                actualAcceleration += acceleration;
            }
        }
        else
        {
            // if moving forward
            if (actualAcceleration > 0.0f)
            {
                // slow down
                actualAcceleration -= acceleration;
            }
        }

        #endregion

        #region angular

        // if holding left
        if (Input.GetKey("a"))
        {
            // if 
            if (actualRotation < maxRotateSpeed)
            {
                actualRotation += rotation;
            }
        }

        if (Input.GetKey("d"))
        {
            // if 
            if (actualRotation > -maxRotateSpeed)
            {
                actualRotation -= rotation;
            }
        }


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

        // apply linear motion
        if (acceleration != 0.0f)
        {
            rb.velocity = (transform.forward * actualAcceleration);
        }

        // apply angular motion
        if (actualRotation > 0.1f)
        {
            rb.rotation = Quaternion.RotateTowards(rb.rotation, rot.transform.rotation, actualRotation);
        }
        else if (actualRotation < -0.1f)
        {
            rb.rotation = Quaternion.RotateTowards(rb.rotation, rot.transform.rotation, actualRotation);
        }
    }     
}