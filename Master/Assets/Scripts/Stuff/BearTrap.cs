﻿using UnityEngine;

public class BearTrap : MonoBehaviour
{
    public GameObject OpenTrap;
    public GameObject ClosedTrap;

    private void OnTriggerEnter(Collider other)
    {
        if (other is BoxCollider) return;
        OpenTrap.SetActive(false);
        ClosedTrap.SetActive(true);
        Destroy(this);
    }
}