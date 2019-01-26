using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private GameObject player;
    private Collider col;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        col = player.GetComponent<BoxCollider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.Equals(col))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
    }

    private void Interact()
    {
        Debug.Log("Interacting...");
    }
}
