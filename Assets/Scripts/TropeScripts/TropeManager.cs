using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
public class TropeManager : MonoBehaviour
{


    private static Trope[] tropes;

    private static Dictionary<long,Trope> tropesTable;
    public static long emptyLastID=0;

    private void Awake()
    {

       Trope[] tropes = Resources.FindObjectsOfTypeAll<Trope>();
       tropesTable = new Dictionary<long, Trope>();

       //поиск свободного идентификатора
       foreach(var trop in tropes)
       {
            if (trop.id > emptyLastID)
            {
                emptyLastID = trop.id;
            }
       }
        emptyLastID++;


        //создание таблицы быстрого доступа к событиям
       foreach(var trop in tropes)
       {
            tropesTable.Add(trop.id, trop);
       }
    }


    public static Trope getTropeById(long _id)
    {

        if (tropesTable.ContainsKey(_id))
        {
            var tropeCopy = tropesTable[_id].getCopy();
            return tropeCopy;
        }

        Debug.Log("TROPE MANAGER: Trope with id - " + _id + " doesnt exist");
        return null;
    }


   

    

}


