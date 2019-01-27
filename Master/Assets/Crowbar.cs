using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : MonoBehaviour
{
    public GameObject Tooltip;
    public GameObject Indicator;

    private void Start()
    {
        Tooltip.SetActive(false);
        Indicator.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Tooltip.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("e"))
        {
            var con = other.GetComponent<PlayerController>();
            if (con != null)
            {
                con.hasCrowbar = true;
                Tooltip.SetActive(false);
                Indicator.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Tooltip.SetActive(false);
    }
}
