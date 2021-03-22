using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JorneyEndBoxElement : BoxElement<JorneyData>
{
    public TextMeshProUGUI jorneyResultHeading;

    private JorneyData jorneyData;

    public override void OnOpen(JorneyData data)
    {
        jorneyData = data;
        updateElement(data);
        EventSystem.Instance.AddEventListener<Event_JorneyStateChanged>(OnJorneyStateChanged);
    }


    public override void OnClose(JorneyData data)
    {
        gameObject.SetActive(false);
        EventSystem.Instance.RemoveEventListener<Event_JorneyStateChanged>(OnJorneyStateChanged);
        
    }


    public void updateElement(JorneyData data)
    {
        switch (data.CurrentState)
        {
            case JorneyData.JorneyState.endedReturn:
                createReturnedPanel(data);
                gameObject.SetActive(true);
                break;

            case JorneyData.JorneyState.endedFail:
                createFailedPanel(data);
                break;
        }
    }


    public void createFailedPanel(JorneyData data)
    {
        if (data.CurrentState == JorneyData.JorneyState.endedFail)
        {
            jorneyResultHeading.text = data.Hero.EntityName + " погиб в странствии!";
        }
    }

    public void createReturnedPanel(JorneyData data)
    {
        if (data.CurrentState == JorneyData.JorneyState.endedReturn)
        {
            jorneyResultHeading.text = data.Hero.EntityName + " вернулся обратно в башню!";
        }
    }


    public void OnJorneyStateChanged(Event_JorneyStateChanged e)
    {
        if (e.jorneyID == jorneyData.Id && jorneyData!=null)
        {
            updateElement(jorneyData);
        }
    }


    public void OnJorneyFinishButtonClick()
    {
        if(jorneyData!=null && jorneyData.CurrentState!=JorneyData.JorneyState.moving && jorneyData.CurrentState != JorneyData.JorneyState.standingTrope)
        {
            EventSystem.Instance.Raise(new GUIEvent_finishJorney(jorneyData.Id));
        }
    }


    public void showBoxElement(JorneyData data)
    {
        updateElement(data);
        gameObject.SetActive(true);    
    }

}
