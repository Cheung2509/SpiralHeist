using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfCarTypes : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> carTypes;

    private void Start()
    {
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

    public List<GameObject> GetList()
    {
        return carTypes;
    }
}
