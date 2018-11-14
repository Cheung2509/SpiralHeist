using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerr : MonoBehaviour
{
    [HideInInspector] public Animator animator;

    public float base_move_speed;
    private float move_speed;

    bool not_moving = true;

    private bool aiming = false;
    private bool running = false;
    private bool crouching = false;

    private bool facing_right = true;

    Actions actions;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        actions = GetComponent<Actions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            actions.Aiming(true);
        }
        else
        {
            actions.Aiming(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            actions.Attack();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            move_speed = base_move_speed / 2;
            crouching = true;
            running = false;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            move_speed = base_move_speed * 1.75f;
            running = true;
            crouching = false;
        }
        else
        {
            move_speed = base_move_speed;
            crouching = false;
            running = false;
        }
        actions.Sitting(crouching);


        not_moving = true;
        if (Input.GetKey(KeyCode.A))
        {
            if(facing_right)
            {
                transform.Rotate(0, 180, 0);
                facing_right = false;
            }
            transform.position += new Vector3(-move_speed * Time.deltaTime, 0, 0);
            actions.Move(running);
            not_moving = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (!facing_right)
            {
                transform.Rotate(0, 180, 0);
                facing_right = true;
            }
            transform.position += new Vector3(move_speed * Time.deltaTime, 0, 0);
            actions.Move(running);
            not_moving = false;
            not_moving = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, move_speed * Time.deltaTime);
            actions.Move(running);
            not_moving = false;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 0, move_speed * Time.deltaTime);
            actions.Move(running);
            not_moving = false;
        }

        if(not_moving)
        {
            actions.Stay();
        }
    }
}
