﻿using System.Collections;
using UnityEngine;

//antiproportional fill amount
public class KeyMover : FillingBar
{
    public GameObject keyHole;
    public float cooldown;
    public DoorMiniGame doorGame;

    bool aiming = true;
    bool succeeded = false;
    Vector3 currentpos;
    Vector3 dir;
    Vector3 midPoint;
    Vector3 drunkVector;
    Vector3 endPos;
    bool drunkFactor = false;
    float timer1 = 0f;
    float timer2 = 0f;
    float timeToAddDrunk = 0f;
    IEnumerator drunk;

    void Start()
    {
        Camera cam = Camera.main;
        midPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        transform.position = new Vector3(Random.Range(-.5f, 1.5f), Random.Range(-.5f, 2f), -.5f);
        endPos = new Vector3(keyHole.transform.position.x, keyHole.transform.position.y, 2.5f);
        StartFill = 0.1f;
    }

    void Update()
    {        
        if (succeeded)
        {
            if (drunk != null) StopCoroutine(drunk);
            StartCoroutine(GoToPos(transform.position,endPos,0.1f));
            succeeded = false;
            aiming = false;
            StartCoroutine(WaitScnd(2f));

        }
        else if(aiming)
        {
            currentpos = Input.mousePosition;
            dir = currentpos - midPoint;

            Vector3 dis = transform.position - keyHole.transform.position;
            transform.position += (dir / 2000);

            timer1 += Time.deltaTime;
            timer2 += Time.deltaTime;

            if (dis.magnitude <= 1f)
            {
                Bar.fillAmount += 1f * Time.deltaTime;
            }
            else Bar.fillAmount -= 0.5f * Time.deltaTime;

            if (Input.GetMouseButton(0) && timer2 >= cooldown && !succeeded)
            {
                Debug.Log("Attempting to open door");
                timer2 = 0f;
                if (dis.magnitude <= 1f && Bar.fillAmount == 1f)
                {
                    Debug.Log("Succeeded");
                    succeeded = true;
                }
                else
                {
                    Debug.Log("Moin");
                    if (drunk != null) StopCoroutine(drunk);
                    StartCoroutine(GoToPos(transform.position, new Vector3(transform.position.x, transform.position.y, -0.4f), .1f, GoToPos(transform.position, new Vector3(transform.position.x, transform.position.y, -.5f), .1f)));
                }
            }
            if (timer1 >= timeToAddDrunk)
            {
                drunk =AddDrunknessFactor();
                StartCoroutine(drunk);
                timer1 = 0f;
                timeToAddDrunk = Random.Range(1f, 1.5f);
            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, keyHole.transform.position.x - 5, keyHole.transform.position.x + 5), Mathf.Clamp(transform.position.y, keyHole.transform.position.y - 5, keyHole.transform.position.y + 5), 0f);
        }
    }

    Vector3 CreateRandomVector(float z)
    {
        return new Vector3(Random.Range(keyHole.transform.position.x -1f , keyHole.transform.position.x + 1f), Random.Range(keyHole.transform.position.y - 1f, keyHole.transform.position.y + 1f), z);
    }

    IEnumerator AddDrunknessFactor()
    {
        float progress = 0f;
        float t = 0f;
        drunkVector = CreateRandomVector(0f);
        //Debug.Log(drunkVector);
        while (progress < 1f)
        {
            Vector3 lerpVec = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(drunkVector.x, drunkVector.y), progress) / 1000;
            Debug.Log(lerpVec);
            transform.position += new Vector3(lerpVec.x, lerpVec.y, 0f);
            t += Time.deltaTime;
            progress = t / 1f;

            yield return null;
        }
    }

    IEnumerator GoToPos(Vector3 start, Vector3 end, float time, IEnumerator callback = null)
    {

        float progress = 0f;
        float t = 0f;
        
        while (progress < 1f)
        {
            transform.position = Vector3.Lerp(start, end, progress);
            t += Time.deltaTime;
            progress = t / time;

            yield return null;
        }
        yield return callback == null ? null : StartCoroutine(callback);
    }

    IEnumerator WaitScnd(float time)
    {
        yield return new WaitForSeconds(time);
        doorGame.DoorOpened();
    }
}
