using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private int walkRightID;
    private int walkLeftID;
    private int crouchID;
    private int crouchRightID;
    private int crouchLeftID;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        animator = GetComponent<Animator>();

        walkRightID = Animator.StringToHash("isWalkingRight");
        walkLeftID = Animator.StringToHash("isWalkingLeft");
        crouchID = Animator.StringToHash("isCrouching");
        crouchLeftID = Animator.StringToHash("isCrouchingLeft");
        crouchRightID = Animator.StringToHash("isCrouchingRight");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool(crouchID, true);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            animator.SetBool(crouchID, false);
        }
        if (rb.velocity.x > 0.25f || Input.GetKey(KeyCode.D))
        {
            animator.SetBool(walkRightID, true);
            animator.SetBool(crouchRightID, true);
        }
        else
        {
            animator.SetBool(walkRightID, false);
            animator.SetBool(crouchRightID, false);
        }

        if (rb.velocity.x < -0.25f || Input.GetKey(KeyCode.A))
        {
            animator.SetBool(walkLeftID, true);
            animator.SetBool(crouchLeftID, true);
        }
        else
        {
            animator.SetBool(walkLeftID, false);
            animator.SetBool(crouchLeftID, false);
        }
    }
}
