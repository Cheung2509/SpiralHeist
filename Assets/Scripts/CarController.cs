using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody rb;

    public float acceleration = 0.0f;


	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown("w"))
        {
            rb.velocity += (transform.forward * acceleration);
        }
	}
}