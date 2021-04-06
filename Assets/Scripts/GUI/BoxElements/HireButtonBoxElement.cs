using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireButtonBoxElement : BoxElement<Hero>
{
    public override void OnClose(Hero data)
    {
        
    }

    public override void OnOpen(Hero data)
    {
        lastData = data;
    }

    public void OnHireButtonClick()
    {
        if(lastData!=null && lastData.State == Hero.HeroState.tavern && lastData.Id.IsInitialized)
        {
            EventSystem.Instance.Raise(new GUIEvent_hireHero(lastData.Id));
        }
    }
}
