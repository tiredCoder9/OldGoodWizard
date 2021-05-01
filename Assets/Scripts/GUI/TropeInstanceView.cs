using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TropeInstanceView : BoxElement<JorneyData>
{
    public bool IsShowing;

    public System.Action OnViewClose;
}
