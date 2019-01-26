using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHole : MonoBehaviour
{
    public GameObject key;
    public Image progressBar;

    public float cooldown;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector3 dis = key.transform.position - transform.position;

        
        if(Input.GetMouseButton(0) && timer >= cooldown)
        {
            Debug.Log("Attempting to open door");
            timer = 0f;
            if (dis.magnitude <= 0.45f)
            {
                Debug.Log("Treffer");
            }
            else Debug.Log("Fail");
        }
    }
}
