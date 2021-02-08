using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class Diary
{
   
    [SerializeField] [JsonProperty] public int noteMaxCount=30;
    [SerializeField] [JsonProperty] private List<DiaryItem> notes;
    [SerializeField] [JsonProperty] private int lastElementIndex;

    [SerializeField] [JsonIgnore] public List<DiaryItem> Notes { get => notes; }

    #region Constructors
    public Diary()
    {
        notes = new List<DiaryItem>();
    }

    [JsonConstructor]
    public Diary(int noteMaxCount, List<DiaryItem> notes, int lastElementIndex)
    {
        this.noteMaxCount = noteMaxCount;
        this.notes = notes;
        this.lastElementIndex = lastElementIndex;
    }

    public Diary(int noteMaxCount)
    {
        this.noteMaxCount = noteMaxCount;
        this.notes = new List<DiaryItem>();
    }
    #endregion

    public void addElement(DiaryItem noteDiary)
    {
        if (notes == null) notes = new List<DiaryItem>();
        notes.Add(noteDiary);
        if (notes.Count > noteMaxCount)
        {
            notes.RemoveAt(0);
        }

        lastElementIndex = notes.Count - 1;
    }


    public DiaryItem getLast()
    {
        return notes[lastElementIndex];
    }

    public int getCount()
    {
        return notes.Count;
    }


}
