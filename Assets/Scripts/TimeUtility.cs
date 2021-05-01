using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeUtility 
{
    public static string timeFromStamp(double time)
    {
        long hours = ((long)time / 3600) % 24;

        long mins = ((long)time / 60) % 60;

        string sh = hours.ToString();
        string sm = mins.ToString();

        if (hours < 9) sh = "0" + sh;
        if (mins < 9) sm = "0" + sm;


        return sh.ToString()+':'+ sm.ToString();
    }
}
