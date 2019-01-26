using UnityEngine;

public delegate void OnHeardSomething();

public abstract class Listener : MonoBehaviour
{
    public float threshold;
    public OnHeardSomething OnHeardSomething { get; protected set; }

    public void Hear(float sourceDistance, float loudness)
    {
        //Debug.Log($"Listener: Heard {loudness /sourceDistance} but needed {threshold}");
        if (loudness / sourceDistance > threshold)
            OnHeardSomething();
    }
}