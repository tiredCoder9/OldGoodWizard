using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static TMPro.TMP_Dropdown;

public class JorneyStartBoxGroup : BoxGroup<AdventureModule>
{
    public void OnStartJorney()
    {
        if(IsOpen) OnBoxClosed.Invoke(lastData);
    }

    public void OnCancelJorney()
    {
        if (IsOpen) OnBoxClosed.Invoke(lastData);
    }

}
