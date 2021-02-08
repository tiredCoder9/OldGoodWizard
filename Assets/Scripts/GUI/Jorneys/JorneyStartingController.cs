using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static TMPro.TMP_Dropdown;

public class JorneyStartingController : MonoBehaviour
{
    private Id adventureID;
    public HeroDropDown dropdown;



    public void OnAdventureSelected(Id _adventure)
    {
        adventureID = _adventure;
        gameObject.SetActive(true); 
    }

    public void OnStart()
    {

        if (dropdown.SelectedHero.IsInitialized && adventureID.IsInitialized)
        {
            EventSystem.Instance.Raise(new GUIEvent_JorneyStartEvent(dropdown.SelectedHero, adventureID));
            gameObject.SetActive(false);
        }
    }

    public void OnCancel()
    {
        gameObject.SetActive(false);
    }


}
