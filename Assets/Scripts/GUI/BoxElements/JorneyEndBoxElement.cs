using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JorneyEndBoxElement : BoxElement<JorneyData>
{

    private JorneyData jorneyData;

    [SerializeField]
    private GameObject jorneyEndFailedPrefab;
    [SerializeField]
    private GameObject jorneyEndReturnPrefab;


    private GameObject currentEndPanel;

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
        if (currentEndPanel != null) Destroy(currentEndPanel);
    }


    public void updateElement(JorneyData data)
    {
        print(data.CurrentState);
        switch (data.CurrentState)
        {
            case JorneyData.JorneyState.endedReturn:   
                gameObject.SetActive(true);
                createReturnedPanel(data);
                break;

            case JorneyData.JorneyState.endedFail:
                gameObject.SetActive(true);
                createFailedPanel(data);
                break;
        }
    }


    public void createFailedPanel(JorneyData data)
    {
        if (data.CurrentState == JorneyData.JorneyState.endedFail)
        {
            currentEndPanel = Instantiate(jorneyEndFailedPrefab, transform);
            var resultView = currentEndPanel.GetComponent<JorneyResultView>();
            resultView.SetValue(data);
            resultView.OnClick += JorneyFinishButtonClick;
        }
    }

    public void createReturnedPanel(JorneyData data)
    {
        if (currentEndPanel != null) Destroy(currentEndPanel);
        if (data.CurrentState == JorneyData.JorneyState.endedReturn)
        {
            currentEndPanel = Instantiate(jorneyEndReturnPrefab, transform);
            var resultView = currentEndPanel.GetComponent<JorneyResultView>();
            resultView.SetValue(data);
            resultView.OnClick += JorneyFinishButtonClick;
        }
    }


    public void OnJorneyStateChanged(Event_JorneyStateChanged e)
    {
        if (e.jorneyID == jorneyData.Id && jorneyData!=null)
        {
            updateElement(jorneyData);
        }
    }


    public void JorneyFinishButtonClick()
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
