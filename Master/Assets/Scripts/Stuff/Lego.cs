using UnityEngine;

public class Lego : MonoBehaviour
{
    public GameObject builtLego;
    public GameObject brokenLego;

    private void Start()
    {
        brokenLego.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other is BoxCollider || other.GetComponent<PlayerController>() == null) return;
        FindObjectOfType<PukeBar>().ChangeFillAmout(0.1f);
        builtLego.SetActive(false);
        brokenLego.SetActive(true);
    }
}