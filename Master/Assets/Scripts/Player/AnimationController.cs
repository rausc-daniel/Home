using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private int walkRightID;
    private int walkLeftID;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        animator = GetComponent<Animator>();

        walkRightID = Animator.StringToHash("isWalkingRight");
        walkLeftID = Animator.StringToHash("isWalkingLeft");
    }

    void Update()
    {
        if (rb.velocity.x > 0.25f || Input.GetKey(KeyCode.D))
        {
            animator.SetBool(walkRightID, true);
        }
        else
        {
            animator.SetBool(walkRightID, false);
        }

        if (rb.velocity.x < -0.25f || Input.GetKey(KeyCode.A))
        {
            animator.SetBool(walkLeftID, true);
        }
        else
        {
            animator.SetBool(walkLeftID, false);
        }
    }
}
