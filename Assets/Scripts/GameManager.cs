using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{


    //global game time in seconds
    public static long _GLOBAL_TIME_
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





    public static long getDateInMinutes()
    {
        return System.DateTime.Now.Ticks / (60 * 10000000);
    }

    public void doStuff() { print("do stuff"); }


}
