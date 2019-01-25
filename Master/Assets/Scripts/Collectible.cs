using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private GameObject player;
    private Collider col;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        col = player.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.Equals(col))
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
    }
}