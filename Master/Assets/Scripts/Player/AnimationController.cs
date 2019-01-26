using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private int walkRightID;
    private int walkLeftID;

    void Start()
    {
        animator = GetComponent<Animator>();

        walkRightID = Animator.StringToHash("isWalkingRight");
        walkLeftID = Animator.StringToHash("isWalkingLeft");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool(walkRightID, true);
        }
        else
        {
            animator.SetBool(walkRightID, false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool(walkLeftID, true);
        }
        else
        {
            animator.SetBool(walkLeftID, false);
        }
    }
}
