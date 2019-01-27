using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        Debug.Log(audio);
    }
    void OnEnable()
    {
        //audio.Play(0);
    }
}
