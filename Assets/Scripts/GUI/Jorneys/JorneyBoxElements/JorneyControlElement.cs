using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JorneyControlElement : BoxElement<JorneyData>
{
    private Id boxID;
    private JorneyData jorneyData;

    public Button failedJorneyButton;
    public Button returnedJorneyButton;
    public Button forwardDirectionButton;
    public Button backwardDirectionButtton;
    public Button tropeFakeButton;

    private Button currentButton;


    public TextMeshProUGUI buttonText;

    public JorneyEndBoxElement EndBoxElement;


    public override void OnOpen(JorneyData data)
    {
        boxID = data.Id;
        jorneyData = data;
        updateElement(data);
        EventSystem.Instance.AddEventListener<Event_JorneyStateChanged>(onJorneyStateChanged);
        EventSystem.Instance.AddEventListener<Event_JorneyDirectionChanged>(onJorneyDirectionChanged);
    }

    public override void OnClose(JorneyData data)
    {
        jorneyData = null;
        EventSystem.Instance.RemoveEventListener<Event_JorneyStateChanged>(onJorneyStateChanged);
        EventSystem.Instance.RemoveEventListener<Event_JorneyDirectionChanged>(onJorneyDirectionChanged);
    }


    public void onJorneyStateChanged(Event_JorneyStateChanged e)
    {
        if (e.jorneyID ==jorneyData.Id)
        {       
            if (jorneyData != null) updateElement(jorneyData);
        }
    }

    public void onJorneyDirectionChanged(Event_JorneyDirectionChanged e)
    {
        if (e.jorneyID == jorneyData.Id)
        {
            if (jorneyData != null) updateElement(jorneyData);
        }
    }


    public void updateElement(JorneyData data)
    {
        failedJorneyButton.gameObject.SetActive(false);
        forwardDirectionButton.gameObject.SetActive(false);
        backwardDirectionButtton.gameObject.SetActive(false);
        tropeFakeButton.gameObject.SetActive(false);

        switch (data.CurrentState)
        {
            case JorneyData.JorneyState.endedFail:
                currentButton = failedJorneyButton;
                currentButton.interactable = true;
                break;

            case JorneyData.JorneyState.endedReturn:
                currentButton = returnedJorneyButton;
                currentButton.interactable = true;
                break;

            case JorneyData.JorneyState.moving:
                switch (data.CurrentDirection)
                {
                    case JorneyData.MovingDirection.forward:
                        currentButton = forwardDirectionButton;
                        currentButton.interactable = true;
                        break;

                    case JorneyData.MovingDirection.backward:
                        currentButton = backwardDirectionButtton;
                        currentButton.interactable = true;
                        break;
                }                 
                break;

            default:
                currentButton = tropeFakeButton;
                currentButton.interactable = false;
                break;
        }

        if(currentButton!=null) currentButton.gameObject.SetActive(true);
    }

    public void OnReturnedButtonClick()
    {
        if (jorneyData != null && jorneyData.CurrentState == JorneyData.JorneyState.endedReturn)
        {
            EndBoxElement.showBoxElement(jorneyData);
        }
    }

    public void OnFailedButtonClick()
    {
        if (jorneyData != null && jorneyData.CurrentState==JorneyData.JorneyState.endedFail)
        {
            EndBoxElement.showBoxElement(jorneyData);
        }
    }

    public void OnForwardButtonClick()
    {
        EventSystem.Instance.Raise(new GUIEvent_ChangeJorneyDirection(jorneyData.Id, JorneyData.MovingDirection.backward));
    }

    public void OnBackwardButtomClick()
    {
        EventSystem.Instance.Raise(new GUIEvent_ChangeJorneyDirection(jorneyData.Id, JorneyData.MovingDirection.forward));
    }



}
