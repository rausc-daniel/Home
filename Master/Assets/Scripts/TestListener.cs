using UnityEngine;

public class TestListener : Listener
{
    private void Awake()
    {
        OnHeardSomething = Log;
    }

    void Log()
    {
        Debug.Log("I heard you!");
    }
}