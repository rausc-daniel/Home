using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    private GameObject player;
    private Collider col;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        col = player.GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.Equals(col))
        {
            PickUp();
        }
    }

    public abstract void PickUp();
}