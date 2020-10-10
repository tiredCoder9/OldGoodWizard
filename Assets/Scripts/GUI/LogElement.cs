using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LogElement : MonoBehaviour
{
    private TMP_Text textRef;
  

    public void setContent(DiaryItem _logContent)
    {
        textRef = GetComponentInChildren<TMP_Text>();
        textRef.SetText(_logContent.getText());
    }

}
