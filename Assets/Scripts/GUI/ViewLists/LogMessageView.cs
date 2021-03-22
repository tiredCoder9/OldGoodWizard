using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogMessageView : ViewElement<DiaryItem>
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI timeText;

    public override void updateView(DiaryItem data)
    {
        text.text = data.text;
        timeText.text = TimeUtility.timeFromStamp(data.time);
    }
}
