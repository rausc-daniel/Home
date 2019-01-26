using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [Range(0, 15)] public float AccelerationSpeed;
    [Range(0, 10)] public float MaxGroundSpeed;
    [Range(0, 10)] public float CrouchSpeed;
    [Range(0, 100)] public float Drunkness;

    private Rigidbody rb;
    private Vector3 speed;
    private Collider crouchCollider;
    private SpriteRenderer spriteRenderer;

    private float inputX;
    private float inputZ;
    private float speedBackup;
    private bool isLookingRight;
    public bool isCrouching;
    public AnimationCurve anim;
    private float time;
    public float timeToAddDrunk = 1.25f;
    private float multiplier = 1;

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
        rb.AddForce(speed * 0.6f);
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -2.5f,2.5f ),0, Mathf.Clamp(rb.velocity.z,-2.5f,2.5f));
        //rb.velocity = 0.1f * speed * current;
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

        if (Math.Abs(inputX) > 0.001f && Math.Abs(inputZ) > 0.001f)
        {
            multiplier = Mathf.Sqrt(2);
        }
        else
        {
            multiplier = 1;
        }

        ChangeDirection();

        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyUp(KeyCode.C))
        {
            Crouch();
        }

        time += Time.deltaTime;

        if (time >= timeToAddDrunk)
        {
            time = 0;
            StartCoroutine(AddDrunknessFactor());
            timeToAddDrunk = Random.Range(1f, 1.5f);
        }
    }

    void FixedUpdate()
    {
        Move();

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, MaxGroundSpeed * -1, MaxGroundSpeed), rb.velocity.y, Mathf.Clamp(rb.velocity.z, MaxGroundSpeed * -1, MaxGroundSpeed));
    }

    IEnumerator AddDrunknessFactor()
    {
        float progress = 0f;
        float t = 0f;
        Vector3 drunkVector = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));

        while (progress < 1f)
        {
            Vector3 lerpVec = Vector3.Lerp(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(drunkVector.x - transform.position.x, 0, drunkVector.z -transform.position.z), progress) / 100;
            rb.velocity += new Vector3(lerpVec.x, 0, lerpVec.z)  ;
            t += Time.deltaTime;
            progress = t;

            yield return null;
        }
    }
}
