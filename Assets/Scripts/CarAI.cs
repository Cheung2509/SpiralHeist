using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{
    public float speed = 5.0f;

	void Update ()
    {
        transform.position += (Time.deltaTime * transform.forward * speed);
	}
}
