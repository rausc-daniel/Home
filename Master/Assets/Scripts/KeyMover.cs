﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMover : MonoBehaviour
{
    Vector3 currentpos;
    Vector3 dir;
    Vector3 midPoint;
    Vector3 drunkVector;

    bool drunkFactor = false;
    float timer = 0f;
    float timeToAddDrunk = 0f;

    public GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        midPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        transform.position = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 2f), -.55f);
        
    }

    // Update is called once per frame
    void Update()
    {
        currentpos = Input.mousePosition;
        dir = currentpos - midPoint;
        transform.position += (dir / 2000);

        timer += Time.deltaTime;
        if (timer >= timeToAddDrunk)
        {
            StartCoroutine(AddDrunknessFactor());
            timer = 0f;
            timeToAddDrunk = Random.Range(1f, 1.5f);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.5f, 1.5f), Mathf.Clamp(transform.position.y, -1f, 1f), -.8f);
    }

    Vector3 CreateRandomVector(float z)
    {
        return new Vector3(Random.Range(0, 2), Random.Range(0, 2), z);
    }

    IEnumerator AddDrunknessFactor()
    {
        float progress = 0f;
        float t = 0f;
        drunkVector = CreateRandomVector(0f);

        while (progress < 1f)
        {
            Vector3 lerpVec = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(drunkVector.x, drunkVector.y), progress) / 100;
            transform.position += new Vector3(lerpVec.x, lerpVec.y, 0f);
            t += Time.deltaTime;
            progress = t / 1f;

            yield return null;
        }
    }

}
