using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryManager : MonoBehaviour
{
    //добавляем новый элемент в дневник
    public static void adventureLog(JorneyData jorneyData, string message)
    {
        jorneyData.diary.addElement(new DiaryItem(jorneyData.timer.innerTime, message));
    }
}
