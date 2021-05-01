using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameManager : MonoBehaviour
{

    public static DateTime baseDate = new DateTime(1970, 1, 1);

    //global game time in seconds
    public static double _GLOBAL_TIME_
    {
        get
        {
            return getDateInMinutes();
        }
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("GAME MANAGER: CURRENT GLOBALTIME " + _GLOBAL_TIME_);
    }





    public static double getDateInMinutes()
    {
        return DateTimeOffset.Now.ToUnixTimeMilliseconds() / 1000.0;
    }

    public void doStuff() { print("do stuff"); }


}
