using UnityEngine;

public class AntiPuke : Collectible
{
    public override void PickUp()
    {
        FindObjectOfType<PukeBar>().ChangeFillAmout(-0.2f);
        Destroy(gameObject);
    }
}