using UnityEngine;
using UnityEngine.AI;

public class Penis : MonoBehaviour
{
    public NavMeshAgent agent;
    private GameObject player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        agent.SetDestination(player.transform.position);

    }
}