using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffects : MonoBehaviour
{
    public ParticleSystem sparks;
    public CarMovement carController;
    public MeshCollider boxCollider;
    [SerializeField]
    private GameObject[] trailWheels;

	// Use this for initialization
	void Start ()
    {

        carController = GetComponent<CarMovement>();
	}

    private void Update()
    {
        if ((GetComponent<CarMovement>().carVelocity > 10) && (Input.GetAxis("Horizontal") != 0))
        {
            foreach (GameObject wheel in trailWheels)
            {
                wheel.GetComponent<TrailRenderer>().emitting = true;
            }
        }
        else
        {
            foreach (GameObject wheel in trailWheels)
            {
                wheel.GetComponent<TrailRenderer>().emitting = false;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (carController.carVelocity > 0)
            {
                Vector3 pos = contact.point;
                Quaternion rot = Quaternion.FromToRotation(Vector3.back, contact.normal);
                ParticleSystem temp = Instantiate(sparks, pos, rot);
                temp.transform.parent = transform;
                temp.loop = false;
                //temp.Emit(1);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if(carController.carVelocity > 0)
            {
                Vector3 pos = contact.point;
                Quaternion rot = Quaternion.FromToRotation(Vector3.back, contact.normal);
                ParticleSystem temp = Instantiate(sparks, pos, rot);
                temp.transform.parent = transform;
                temp.loop = false;
                //temp.Emit(1);
            }
        }
    }
}
