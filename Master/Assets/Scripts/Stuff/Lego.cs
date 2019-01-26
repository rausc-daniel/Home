using UnityEngine;

public class Lego : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other is BoxCollider) return;
        Debug.Log("Penis");
        FindObjectOfType<PukeBar>().ChangeFillAmout(0.1f);
    }
}