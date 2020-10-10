using UnityEngine;
using UnityEditor;
[System.Serializable]
public class DiaryItem
{
    [ReadOnly]
    public long time;

    [ReadOnly]
    public string text;

    public DiaryItem(long _time=0, string _text="PLACEHOLDER")
    {
        time = _time;
        text = _text;
    }

    public string getText()
    {
        return text;
    }

    public long getTime()
    {
        return time;
    }
}
