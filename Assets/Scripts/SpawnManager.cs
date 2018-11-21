using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float timeBetweenSpawns = 0.0f;
    public float maxDistanceToSpawn = 0.0f;

    private GameObject player;

    [SerializeField]
    private float timeSinceLastSpawn = 0.0f;
    [SerializeField]
    private List<GameObject> carTypes;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        GameObject AI_Car = (GameObject)Resources.Load("AI_Car", typeof(GameObject));
        carTypes.Add(AI_Car);
        GameObject AI_Cruiser = (GameObject)Resources.Load("AI_Cruiser", typeof(GameObject));
        carTypes.Add(AI_Cruiser);
        GameObject AI_Taxi = (GameObject)Resources.Load("AI_Taxi", typeof(GameObject));
        carTypes.Add(AI_Taxi);
        GameObject AI_Van = (GameObject)Resources.Load("AI_Van", typeof(GameObject));
        carTypes.Add(AI_Van);
        GameObject AI_Wagon = (GameObject)Resources.Load("AI_Wagon", typeof(GameObject));
        carTypes.Add(AI_Wagon);
    }

    void Update ()
    {
		if (Vector3.Distance(transform.position, player.transform.position) < maxDistanceToSpawn)
        {
            timeSinceLastSpawn += Time.deltaTime;
        }

        if (timeSinceLastSpawn > timeBetweenSpawns)
        {
            Instantiate(carTypes[Random.Range(0, carTypes.Count)], transform);

            timeSinceLastSpawn = 0.0f;
        }
	}
}
