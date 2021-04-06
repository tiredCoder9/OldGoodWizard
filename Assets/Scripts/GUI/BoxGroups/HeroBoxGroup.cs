using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeroBoxGroup : BoxGroup<Hero>
{

    public void OnCloseButtonclick()
    {
       if (lastData != null) OnBoxClose.Invoke();
    }

}
