using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHole : FillingBar
{
    public GameObject key;
    public float cooldown;
    private float timer;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector3 dis = key.transform.position - transform.position;

        if (dis.magnitude <= 0.1f)
        {
            Bar.fillAmount += 1f * Time.deltaTime;
        }
        else Bar.fillAmount -= 0.5f * Time.deltaTime;

        if (Input.GetMouseButton(0) && timer >= cooldown)
        {
            Debug.Log("Attempting to open door");
            timer = 0f;
            if (dis.magnitude <= 0.1f && Bar.fillAmount == 1f)
            {
                Debug.Log("Door opened Bitch");
            }
            else Debug.Log("You suck");
        }
    }
}
