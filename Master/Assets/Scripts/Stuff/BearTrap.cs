using UnityEngine;

public class BearTrap : MonoBehaviour
{
    public GameObject OpenTrap;
    public GameObject ClosedTrap;
    public GameObject Indicator;

    private void OnTriggerEnter(Collider other)
    {
        var controller = other.GetComponent<PlayerController>();
        if (controller)
        {
            OpenTrap.SetActive(false);
            ClosedTrap.SetActive(true);
            Destroy(this);
            if (!controller.hasCrowbar)
                controller.Die();
            Indicator?.SetActive(false);
        }
    }
}