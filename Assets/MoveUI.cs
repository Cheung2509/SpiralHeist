using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUI : MonoBehaviour
{
    [SerializeField]
    private int move_speed;

    [SerializeField]
    private Vector3 move_direction;

    [SerializeField]
    private bool moving = false;

	
	// Update is called once per frame
	void Update ()
    {
		if(moving)
        {
            transform.position += (move_direction) * move_speed;
        }
	}

    public void Move(bool _moving)
    {
        moving = _moving;
    }
}
