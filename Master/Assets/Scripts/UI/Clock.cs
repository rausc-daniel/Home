using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Clock : MonoBehaviour
{
    public GameObject MinuteHand;
    public GameObject HourHand;
    public float FiveMinutes;
    public NavMeshAgent Sister;
    public GameObject dest1;
    public GameObject dest2;

    private Quaternion minuteStartRot;
    private Quaternion hourStartRot;

    private void Awake()
    {
        DoorMiniGame.onLockFinished += Init;
    }

    private void Init()
    {
        CurrentTime.CurrentHour = 2;
        CurrentTime.CurrentMinute = 0;
        MinuteHand.transform.rotation = Quaternion.Euler(0, 0, -CurrentTime.CurrentMinute * 6);
        HourHand.transform.rotation = Quaternion.Euler(0, 0, -CurrentTime.CurrentHour * 30 - CurrentTime.CurrentMinute * 0.5f);
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
        CurrentTime.CurrentMinute += 5;

        if (CurrentTime.CurrentMinute == 60)
        {
            CurrentTime.CurrentHour++;
            CurrentTime.CurrentMinute = 0;
        }

        if (CurrentTime.CurrentHour == 12)
            CurrentTime.CurrentHour = 0;

        if (CurrentTime.CurrentMinute == 0 || CurrentTime.CurrentMinute == 30)
        {
            Sister.SetDestination(dest1.transform.position);
        }
        if (CurrentTime.CurrentMinute == 15 || CurrentTime.CurrentMinute == 45)
        {
            Sister.SetDestination(dest2.transform.position);
        }

        yield return StartCoroutine(Hour());
    }
}