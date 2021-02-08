using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JorneyBox : BoxGroup<JorneyData>
{
    public void OnCloseButtonClick()
    {
        OnBoxClosed.Invoke(lastData);
    }
}
