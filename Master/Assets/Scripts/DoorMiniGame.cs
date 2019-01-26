using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorMiniGame : MonoBehaviour
{
    public GameObject schloss;
    public GameObject keyHole;
    public GameObject key;
    public Image bar;

    void Start()
    {
        ActivateDoor();
    }
    public void ActivateDoor()
    {
        schloss.SetActive(true);
        keyHole.SetActive(true);
        key.SetActive(true);
        bar.transform.gameObject.SetActive(true);
    }
}
