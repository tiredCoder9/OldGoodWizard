using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Diary
{

    public List<DiaryItem> notes;


    public void addElement(DiaryItem noteDiary)
    {
        if (notes == null) notes = new List<DiaryItem>();
        notes.Add(noteDiary);
        if (notes.Count > 30)
        {
            notes.RemoveAt(0);
        }
        
        
    }

}
