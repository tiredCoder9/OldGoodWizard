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
    private DiaryItem lastElement;


    public void addElement(DiaryItem noteDiary)
    {
        if (notes == null) notes = new List<DiaryItem>();
        lastElement = noteDiary;
        notes.Add(noteDiary);
        if (notes.Count > noteMaxCount)
        {
            notes.RemoveAt(0);
        }
        
        
    }


    public DiaryItem getLast()
    {
        return lastElement;
    }

    public int getCount()
    {
        return notes.Count;
    }


}
