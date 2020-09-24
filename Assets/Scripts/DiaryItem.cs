[System.Serializable]
public class DiaryItem
{
    public long time;
    public string text;

    public DiaryItem(long _time=0, string _text="PLACEHOLDER")
    {
        time = _time;
        text = _text;
    }
}
