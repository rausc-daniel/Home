using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject WinScreen;

    private void Start()
    {
        WinScreen.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>())
            WinScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
