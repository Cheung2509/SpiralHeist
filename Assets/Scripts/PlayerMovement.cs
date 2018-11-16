using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private CapsuleCollider col;

    public float movementSpeed = 10.0f;
    public float jumpForce = 5.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        Movement();
        Jump();
        Attack();
    }

    void Movement()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, rb.velocity.y, Input.GetAxis("Vertical") * movementSpeed);
        animator.SetFloat("speedPercentage", rb.velocity.x);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            animator.SetBool("jumping", true);
        }

        if (animator.GetAnimatorTransitionInfo(0).IsName("Layer.Land -> Layer.Idle"))
        {
            // The landing animation is getting triggered before the character physically lands.
            // Must implement a "ground" check in order to fix this.
            animator.SetBool("jumping", false);
        }
    }

    void Attack()
    {
        if (Input.GetButtonDown("AttackR"))
        {
            animator.SetTrigger("attackR");
        }
        if(Input.GetButtonDown("KickL"))
        {
            animator.SetTrigger("kickL");
        }
    }

}
