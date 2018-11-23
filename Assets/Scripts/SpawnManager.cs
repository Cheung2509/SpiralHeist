using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float timeBetweenSpawns = 0.0f;
    public float vehicleStartSpeed = 0.0f;
    public bool vehicleHasLifetime = false;
    public float vehicleLifetime = 0.0f;
    public bool vehicleHasMaxDistance = false;
    public float vehicleMaxDistance = 0.0f;
    public float separation = 0.0f;

    private GameObject player;
    private GameObject vehicle;
    private VehicleAI ai;
    private GameObject tempVehicle;

    [SerializeField]
    private float timeSinceLastSpawn = 0.0f;
    [SerializeField]
    private List<GameObject> VehicleTypes;
    [SerializeField]
    private float distanceToLastSpawned = 10000.0f;
    [SerializeField]
    private float necessaryDistanceToSpawn = 0.0f;
    [SerializeField]
    private bool nextVehiclePicked = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        vehicle = null;
        tempVehicle = null;

        VehicleTypes = GameObject.FindGameObjectWithTag("CarTypes").GetComponent<ListOfVehicleTypes>().GetList();
    }

    void Update ()
    {
		if (Vector3.Distance(transform.position, player.transform.position) < vehicleMaxDistance)
        {
            timeSinceLastSpawn += Time.deltaTime;
        }

        if (!nextVehiclePicked)
        {
            tempVehicle = VehicleTypes[Random.Range(0, VehicleTypes.Count)];

            if (vehicle != null)
            {
                necessaryDistanceToSpawn = ai.distanceToRear + separation + tempVehicle.GetComponent<VehicleAI>().distanceToFront;
            }
            else
            {
                necessaryDistanceToSpawn = 0.0f;
            }

            nextVehiclePicked = true;
        }

        if (timeSinceLastSpawn > timeBetweenSpawns && distanceToLastSpawned > necessaryDistanceToSpawn)
        {                      
            vehicle = Instantiate(tempVehicle, transform);

            ai = vehicle.GetComponent<VehicleAI>();

            ai.SetSpeed(vehicleStartSpeed);

            if (vehicleHasLifetime)
            {
                ai.SetTimeUntilDeath(vehicleLifetime);
            }

            if (vehicleHasMaxDistance)
            {
                ai.SetMaxDistance(vehicleMaxDistance);
            }
            
            timeSinceLastSpawn = 0.0f;

            nextVehiclePicked = false;
        }

        //Debug.Log(vehicle);

        if (vehicle != null)
        {
            distanceToLastSpawned = Vector3.Distance(vehicle.transform.position, transform.position);
        }
        else
        {
            distanceToLastSpawned = 10000.0f;
        }
	}
}
