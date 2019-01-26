using UnityEngine;

public class Bottle : Collectible
{
    public override void PickUp()
    {
        FindObjectOfType<PukeBar>().ChangeFillAmout(0.2f);
        Destroy(gameObject);
    }
}