using UnityEngine;
using System;

public class ShowTime : MonoBehaviour
{

  private const float
      hoursToDegrees = 360f / 12f,
      minutesToDegrees = 360f / 60f,
      secondsToDegrees = 360f / 60f;

  public Transform hours, minutes, seconds;
  public bool analog;

  void Update()
  {
    if (analog)
    {
      TimeSpan timespan = DateTime.Now.TimeOfDay;
      hours.localRotation =
          Quaternion.Euler((float)timespan.TotalHours * hoursToDegrees, 0f, 0f); // Depending on the rotation of the clock determines where the hand is located and whether its a positive or negative interger
      minutes.localRotation =
          Quaternion.Euler((float)timespan.TotalMinutes * minutesToDegrees, 0f, 0f);
      seconds.localRotation =
          Quaternion.Euler((float)timespan.TotalSeconds * secondsToDegrees, 0f, 0f);
    }
    else
    {
      DateTime time = DateTime.Now;
      hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
      minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
      seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
    }
  }
}