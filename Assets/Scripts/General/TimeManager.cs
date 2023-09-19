using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeManager
{
    public static bool TIMEISSTOPPED = false;
    public static void StopTime()
    {
        Time.timeScale = 0f;
        TIMEISSTOPPED = true;
    }

    public static void ResumeTime()
    {
        Time.timeScale = 1f;
        TIMEISSTOPPED = false;
    }
}
