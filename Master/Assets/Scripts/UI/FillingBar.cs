using UnityEngine;
using UnityEngine.UI;

public abstract class FillingBar : MonoBehaviour
{
    public Image Bar;
    public float StartFill;

    private void Start()
    {
        Bar.fillAmount = StartFill;
        Debug.Log(StartFill);
    }
}