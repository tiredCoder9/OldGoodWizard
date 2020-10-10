using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Diary
{
    [SerializeField]
    

    public List<DiaryItem> Notes { get => notes; }
    public int noteMaxCount=30;
    [SerializeField]
    private List<DiaryItem> notes;

    public void addElement(DiaryItem noteDiary)
    {
        if (notes == null) notes = new List<DiaryItem>();
        notes.Add(noteDiary);
        if (notes.Count > noteMaxCount)
        {
            notes.RemoveAt(0);
        }
        
        
    }

}
