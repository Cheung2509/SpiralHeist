using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.0f;
    [SerializeField]
    private float lifetime = 3600.0f;
    [SerializeField]
    private float maxDistance = 10000.0f;
    [SerializeField]
    private float distance = 0.0f;

    public float distanceToRear = 0.0f;
    public float distanceToFront = 0.0f;

    void Update()
    {
        transform.position += (Time.deltaTime * transform.forward * speed);

        distance = Vector3.Distance(transform.position, transform.parent.position);

        if (lifetime < 0.0f || distance > maxDistance)
        {
            Destroy(gameObject);
        }
        else
        {
            lifetime -= Time.deltaTime;
        }
    }
    
    public void SetSpeed(float value)
    {
        speed = value;
    }

    public void SetTimeUntilDeath(float value)
    {
        lifetime = value;
    }

    public void SetMaxDistance(float value)
    {
        maxDistance = value;
    }  
}

