using UnityEngine;
using UnityEngine.AI;

public class Sister : MonoBehaviour
{
    public NavMeshAgent agent;
    private SpriteRenderer sr;
    private Animator anim;
    private int walkID;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        walkID = Animator.StringToHash("isWalking");
    }

    private void Update()
    {
        Debug.Log(agent.velocity.x);
        anim.SetBool(walkID, Mathf.Abs(agent.velocity.x) > 0.001f);

        if (agent.velocity.x > 0)
        {
            sr.flipX = false;
        }

        if (agent.velocity.x < 0)
        {
            sr.flipX = true;
        }

        sr.sortingOrder = -(int) (transform.position.z * 100);
    }
}