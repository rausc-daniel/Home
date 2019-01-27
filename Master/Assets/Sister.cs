using UnityEngine;

public class Sister : MonoBehaviour
{
    public PukeBar bar;

    //private void Start()
    //{
    //    bar = FindObjectOfType<PukeBar>();
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>() == null) return;
        bar.ChangeFillAmout(0.1f * Time.deltaTime);
    }
}