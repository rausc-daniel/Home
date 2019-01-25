using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public GameObject MinuteHand;
    public GameObject HourHand;
    public CurrentTime currentTime;
    public float Speed;

    private float time;
    private Quaternion minuteStartRot;
    private Quaternion hourStartRot;

    private void Start()
    {
        currentTime = new CurrentTime(2, 0);
        minuteStartRot = Quaternion.identity;
        hourStartRot = Quaternion.identity;
        StartCoroutine(Hour());
    }

    private IEnumerator Hour()
    {
        float targetZ = minuteStartRot.z - 5;
        Quaternion minuteTargetRot = Quaternion.Euler(0, 0, targetZ);
        targetZ = hourStartRot.z - 5 / 12;
        Quaternion hourTargetRot = Quaternion.Euler(0, 0, targetZ);
        float progress = 0;
        float current = 0;

        while (progress < 1)
        {
            current += Time.deltaTime;
            progress = current / 12;
            HourHand.transform.rotation = Quaternion.Slerp(hourStartRot, hourTargetRot, progress);
            yield return null;
        }
    }
}