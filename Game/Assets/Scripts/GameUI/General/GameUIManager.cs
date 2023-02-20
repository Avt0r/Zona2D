using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameUIManager
{
    public static Action<int> INFOLEVEL;
    public static Action<float> INFOXP;
    public static Action<float> INFOHP;
    public static Action<float> INFOSTAMINA;
    public static Action<string> INFOAMMO;
    public static Action RELOADSTART;
    public static Action RELOADSTOP;
    public static Action<Transform> CAMERAFOLLOW;
    public static Action SHOWDEATHSCREEN;
}
