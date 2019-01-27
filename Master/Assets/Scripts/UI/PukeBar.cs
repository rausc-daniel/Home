using UnityEngine;

public class PukeBar : FillingBar
{
    public float FillPerFrame;

    private void Update()
    {
        Bar.fillAmount += FillPerFrame;

        if (Bar.fillAmount >= 1)
        {
            // Penis
        }
    }

    public void ChangeFillAmout(float amount)
    {
        Bar.fillAmount += amount;
    }

    public void ResetBar()
    {
        Bar.fillAmount = 0;
    }
}