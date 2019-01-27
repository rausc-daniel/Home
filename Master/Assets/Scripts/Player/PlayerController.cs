using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [Range(0, 15)] public float AccelerationSpeed;
    [Range(0, 10)] public float MaxGroundSpeed;
    [Range(0, 10)] public float CrouchSpeed;
    [Range(0, 100)] public float Drunkness;

    public LayerMask layerMask;
    private Rigidbody rb;
    private Collider crouchCollider;
    private SpriteRenderer spriteRenderer;
    private Collider collider;
    private Vector3 speed;

    private float inputX;
    private float inputZ;
    private float speedBackup;
    private bool isLookingRight;
    public bool isCrouching;
    private float time;
    public float timeToAddDrunk = 1.25f;
    public int walkingSpeed;

    public GameObject GameOverScreen;

    public bool hasCrowbar = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        speedBackup = AccelerationSpeed;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        collider = GetComponent<Collider>();

        GameOverScreen.SetActive(false);
    }

    private void Move()
    {
        speed = new Vector3(inputX * AccelerationSpeed, rb.velocity.y, inputZ * AccelerationSpeed);
        rb.AddForce(speed);
        //rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -2.5f,2.5f ),0, Mathf.Clamp(rb.velocity.z,-2.5f,2.5f));
        //rb.velocity = 0.1f * speed * current;
    }

    private void SlopeDetection()
    {
        float angle;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f, layerMask))
        {
            angle = Mathf.Abs((Mathf.Atan2(hit.normal.x, hit.normal.y) * Mathf.Rad2Deg));
            // slide
            if (angle > 46)
            { }
            // stabilize
            else if (angle < 46)
            {
                rb.AddExplosionForce(3, collider.bounds.min, 1);
            }
        }
    }
    
    //private void ChangeDirection()
    //{
    //    isLookingRight = !isLookingRight;

    //    if (isLookingRight && inputX > 0)
    //    {
    //        spriteRenderer.flipX = false;
    //    }
    //    else if (!isLookingRight && inputX < 0)
    //    {
    //        spriteRenderer.flipX = true;
    //    }
    //}

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
        SlopeDetection();

        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");

        //ChangeDirection();

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.LeftControl))
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

        spriteRenderer.sortingOrder = -(int) (transform.position.z * 100);
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

    public void Die()
    {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
