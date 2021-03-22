using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JorneyStartBoxElement : BoxElement<AdventureModule>
{
    public HeroDropDown dropDown;
    public SelectedAdventureBoxElement adventure;

    public Button startButton;
    public override void OnClose(AdventureModule data)
    {
        
    }

    public override void OnOpen(AdventureModule data)
    {
        updateElement();
    }

    public void updateElement()
    {
        startButton.interactable = dropDown.SelectedHero.IsInitialized && adventure.selectedAdventureId.IsInitialized;
    }

    public void OnStartJorney()
    {
        if (dropDown.SelectedHero.IsInitialized && adventure.selectedAdventureId.IsInitialized)
        {
            EventSystem.Instance.Raise(new GUIEvent_JorneyStartEvent(dropDown.SelectedHero, adventure.selectedAdventureId));
        }

    }
}
