using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Smash");

            foreach (Transform child in transform)
            {
                Debug.Log(child.gameObject.name);

                child.GetComponent<Rigidbody>().isKinematic = false;
                child.GetComponent<Rigidbody>().AddExplosionForce(100,other.transform.position, 10);
            }

            
            GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().WindowSmashed();
        }
    }
}
