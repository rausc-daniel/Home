using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public GameObject MinuteHand;
    public GameObject HourHand;
    public CurrentTime Current;
    public float FiveMinutes;

    private Quaternion minuteStartRot;
    private Quaternion hourStartRot;

    private void Start()
    {
        Current = new CurrentTime(2, 0);
        MinuteHand.transform.rotation = Quaternion.Euler(0, 0, -Current.CurrentMinute * 6);
        HourHand.transform.rotation = Quaternion.Euler(0, 0, -Current.CurrentHour * 30 - Current.CurrentMinute * 0.5f);
        minuteStartRot = MinuteHand.transform.rotation;
        hourStartRot = HourHand.transform.rotation;
        StartCoroutine(Hour());
    }

    private IEnumerator Hour()
    {
        float minuteTargetZ = MinuteHand.transform.eulerAngles.z - 30;
        float hourTargetZ = HourHand.transform.eulerAngles.z - 30f / 12;
        Quaternion minuteTargetRot = Quaternion.Euler(0, 0, minuteTargetZ);
        Quaternion hourTargetRot = Quaternion.Euler(0, 0, hourTargetZ);

        float progress = 0;
        float current = 0;

        while (progress < 1)
        {
            current += Time.deltaTime;
            progress = current / FiveMinutes;
            MinuteHand.transform.rotation = Quaternion.Slerp(minuteStartRot, minuteTargetRot, progress);
            HourHand.transform.rotation = Quaternion.Slerp(hourStartRot, hourTargetRot, progress);
            yield return null;
        }

        minuteStartRot = minuteTargetRot;
        hourStartRot = hourTargetRot;
        Current.CurrentMinute += 5;

        if (Current.CurrentMinute == 60)
        {
            Current.CurrentHour++;
            Current.CurrentMinute = 0;
        }

        if (Current.CurrentHour == 12)
            Current.CurrentHour = 0;

        Debug.Log(Current.CurrentHour + ":" + Current.CurrentMinute);

        yield return StartCoroutine(Hour());
    }
}