using UnityEngine;

public class SoundEmitter : MonoBehaviour
{
    public Collider[] heardMe;
    private LayerMask mask = 1 << 9;

    public float loudness;
    private DizzinessEffect Effect;

    private void Awake()
    {
        Effect = Camera.main.GetComponent<DizzinessEffect>();
    }

    void EmitSound()
    {
        //Debug.Log("Sound Emitted");
        heardMe = Physics.OverlapSphere(transform.position, loudness, mask, QueryTriggerInteraction.Ignore);
        foreach (var obj in heardMe)
        {
            var listener = obj.GetComponent<Listener>();

            listener.Hear(Vector3.Distance(transform.position, obj.transform.position), loudness);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other is BoxCollider) return;

        var rnd = Random.Range(0, Effect.Threshold);
        //Debug.Log($"OnTrigger Enter: Got {rnd} but needed smaller than {Effect.Dizziness}");
        if (rnd < Effect.Dizziness)
        {
            EmitSound();
        }
    }
}
