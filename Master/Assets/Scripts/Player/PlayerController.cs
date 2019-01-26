using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range (0, 15)] public float AccelerationSpeed;
    [Range (0, 10)] public float MaxGroundSpeed;
    [Range (0, 10)] public float CrouchSpeed;
    [Range (0, 100)] public float Drunkness;

    private Rigidbody rb;
    private Vector3 speed;
    private Collider crouchCollider;
    private SpriteRenderer spriteRenderer;

    private float inputX;
    private float inputZ;
    private float speedBackup;
    private bool isLookingRight;
    public bool isCrouching;

    void Start()
    {
        //animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        speedBackup = AccelerationSpeed;
    }

    private void Move()
    {
        speed = new Vector3(inputX * AccelerationSpeed, rb.velocity.y, inputZ * AccelerationSpeed);
        //rb.AddForce(speed);
        rb.velocity = speed;
    }

    private void ChangeDirection()
    {
        isLookingRight = !isLookingRight;

        if (isLookingRight && inputX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (!isLookingRight && inputX < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void Crouch()
    {
        isCrouching = !isCrouching;
        if (isCrouching)
        {
            AccelerationSpeed = CrouchSpeed;
        }
        else if (!isCrouching)
        {
            AccelerationSpeed = speedBackup;
        }
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");

        ChangeDirection();

        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyUp(KeyCode.C))
        {
            Crouch();
        }
    }

    void FixedUpdate()
    {
        Move();

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, MaxGroundSpeed * -1, MaxGroundSpeed), rb.velocity.y, Mathf.Clamp(rb.velocity.z, MaxGroundSpeed * -1, MaxGroundSpeed));
    }
}
