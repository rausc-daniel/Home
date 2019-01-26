using UnityEngine;

public class Lego : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other is BoxCollider) return;
        FindObjectOfType<PukeBar>().ChangeFillAmout(0.1f);
    }
}