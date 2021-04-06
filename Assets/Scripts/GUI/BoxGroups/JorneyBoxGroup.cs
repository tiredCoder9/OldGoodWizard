using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JorneyBoxGroup : BoxGroup<JorneyData>
{
    public void OnCloseButtonClick()
    {
        OnBoxClose.Invoke();
    }
}
