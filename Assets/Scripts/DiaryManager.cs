using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryManager : MonoBehaviour
{





    //добавляем новый элемент в дневник
    public static void adventureLog(JorneyData jorneyData, string message)
    {
        jorneyData.Diary.addElement(new DiaryItem(jorneyData.Timer.innerTime, message));
        
        
    }

    //TODO: может все-таки сделать текст в виде SO?


    public static void adventureLog(JorneyData jorney, DiaryDialog dialog)
    {
        jorney.Diary.addElement(dialog);
    }




}
