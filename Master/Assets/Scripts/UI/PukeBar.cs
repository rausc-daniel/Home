using UnityEngine;

public class PukeBar : FillingBar
{
    public float FillPerFrame;

    private void Update()
    {
        Bar.fillAmount += FillPerFrame;
    }

    public void ChangeFillAmout(float amount)
    {
        Bar.fillAmount += amount;
    }
}