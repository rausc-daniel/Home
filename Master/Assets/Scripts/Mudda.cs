using UnityEngine;
using UnityEngine.AI;

public class Mudda : MonoBehaviour
{
    public NavMeshAgent agent;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (agent.velocity.x > 0)
        {
            sr.flipX = false;
        }

        if (agent.velocity.x < 0)
        {
            sr.flipX = true;
        }
    }
}