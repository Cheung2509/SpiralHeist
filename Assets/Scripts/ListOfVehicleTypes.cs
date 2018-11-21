using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfVehicleTypes : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> vehicleTypes;

    private void Start()
    {
        GameObject AI_Car = (GameObject)Resources.Load("AI_Car", typeof(GameObject));
        vehicleTypes.Add(AI_Car);
        GameObject AI_Cruiser = (GameObject)Resources.Load("AI_Cruiser", typeof(GameObject));
        vehicleTypes.Add(AI_Cruiser);
        GameObject AI_Taxi = (GameObject)Resources.Load("AI_Taxi", typeof(GameObject));
        vehicleTypes.Add(AI_Taxi);
        GameObject AI_Van = (GameObject)Resources.Load("AI_Van", typeof(GameObject));
        vehicleTypes.Add(AI_Van);
        GameObject AI_Wagon = (GameObject)Resources.Load("AI_Wagon", typeof(GameObject));
        vehicleTypes.Add(AI_Wagon);
        GameObject AI_Bus = (GameObject)Resources.Load("AI_Bus", typeof(GameObject));
        vehicleTypes.Add(AI_Bus);
        GameObject AI_Rig = (GameObject)Resources.Load("AI_Rig", typeof(GameObject));
        vehicleTypes.Add(AI_Rig);
    }

    public List<GameObject> GetList()
    {
        return vehicleTypes;
    }
}
