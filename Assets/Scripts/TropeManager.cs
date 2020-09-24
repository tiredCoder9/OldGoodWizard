using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
public class TropeManager : MonoBehaviour
{
    public int lastTropeId
    {
        get
        {
            return PlayerPrefs.GetInt("LAST_TROPE_ID");
        }
    }
    private void Awake()
    {
       if(lastTropeId==0) PlayerPrefs.SetInt("LAST_TROPE_ID", 0);
       int i = lastTropeId;
       Trope[] tropes = Resources.FindObjectsOfTypeAll<Trope>();
       foreach(Trope trope in tropes)
        {
            if (trope.id == 0)
            {
                i++;
                trope.id = i;
                PlayerPrefs.SetInt("LAST_TROPE_ID", i);
            }
        }
    }
}


