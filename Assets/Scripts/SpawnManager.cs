using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float timeBetweenSpawns = 0.0f;
    public float carStartSpeed = 0.0f;
    public bool carHasLifetime = false;
    public float carLifetime = 0.0f;
    public bool carHasMaxDistance = false;
    public float carMaxDistance = 0.0f;

    private GameObject player;

    [SerializeField]
    private float timeSinceLastSpawn = 0.0f;
    [SerializeField]
    private List<GameObject> carTypes;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        carTypes = GameObject.FindGameObjectWithTag("CarTypes").GetComponent<ListOfCarTypes>().GetList();
    }

    void Update ()
    {
		if (Vector3.Distance(transform.position, player.transform.position) < carMaxDistance)
        {
            timeSinceLastSpawn += Time.deltaTime;
        }

        if (timeSinceLastSpawn > timeBetweenSpawns)
        {
            GameObject car = Instantiate(carTypes[Random.Range(0, carTypes.Count)], transform);

            CarAI ai = car.GetComponent<CarAI>();

            ai.SetSpeed(carStartSpeed);

            if (carHasLifetime)
            {
                ai.SetTimeUntilDeath(carLifetime);
            }

            if (carHasMaxDistance)
            {
                ai.SetMaxDistance(carMaxDistance);
            }

            timeSinceLastSpawn = 0.0f;
        }
	}
}
