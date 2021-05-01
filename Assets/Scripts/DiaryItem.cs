using UnityEngine;
using UnityEditor;
[System.Serializable]
public class DiaryItem
{
    [ReadOnly]
    public double time;

    [ReadOnly]
    public string text;

    public DiaryItem(double _time=0, string _text="PLACEHOLDER")
    {
        time = _time;
        text = _text;
    }

    public string getText()
    {
        return text;
    }

    public double getTime()
    {
        return time;
    }
}
