using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeUtility 
{
    public static string timeFromStamp(long time)
    {
        return ((time/60) % 24).ToString()+':'+ (time % 60).ToString();
    }
}
