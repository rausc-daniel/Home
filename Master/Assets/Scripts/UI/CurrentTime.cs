using UnityEngine;

public struct CurrentTime
{
    public int CurrentHour;
    public int CurrentMinute;

    public CurrentTime(int hour, int minute)
    {
        CurrentHour = hour;
        CurrentMinute = minute;
    }
}