using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TropeControllerBoxElement : BoxElement<JorneyData>
{
    [SerializeField]
    GameObject BattleTropeBoxPrefab;

    GameObject currentBox;

    private TropeInstanceView currentView;

    public override void OnOpen(JorneyData data)
    {
        UpdateTropeSection(data);
        EventSystem.Instance.AddEventListener<Event_JorneyStateChanged>(OnJorneyTropeStarted);
        lastData = data;
    }

    private void OnJorneyTropeStarted(Event_JorneyStateChanged e)
    {
        if (e != null)
        {
            JorneyData data = JorneyDataManager.Instance.getJorneyDataByID(e.jorneyID);
            if (data!=null && lastData.Id == data.Id)
            {
                UpdateTropeSection(lastData);
            }
        }
    }

    private void UpdateTropeSection(JorneyData data)
    {
        var Trope = data.CurrentTrope;
        if (Trope != null && !Trope.IsEnded)
        {
            if (currentBox != null)
            {
                DestroyViewInstanceIfExists(data);
            }


            if (Trope is BattleTropeInstance)
            {
                CreateViewInstance(data);
                currentView.OnOpen(data);
            }
        }
        else
        {
            if (currentBox != null)
            {
                DestroyViewInstanceIfExists(data);
            }
        }

    }

    public void CreateViewInstance(JorneyData data)
    {
        var CurrentTrope = data.CurrentTrope;
        if(CurrentTrope is BattleTropeInstance && !CurrentTrope.IsEnded)
        {
            var obj = CreateBattleTropeView(data);
            currentView = obj?.GetComponent<TropeInstanceView>();
            currentBox = obj;
        }
    }

    public void DestroyViewInstanceIfExists(JorneyData data)
    {
        if (currentBox != null)
        {
            currentBox.GetComponent<BoxElement<JorneyData>>().OnClose(data);
            Destroy(currentBox);
            currentBox = null;
            currentView = null;
        }
    }


    public GameObject CreateBattleTropeView(JorneyData jorney)
    {
        if(jorney.CurrentTrope is BattleTropeInstance)
        {
            currentBox = Instantiate(BattleTropeBoxPrefab, transform);
            return currentBox;
        }
        return null;
    }

    public override void OnClose(JorneyData data)
    {
        if (currentBox != null)
        {
            currentBox.GetComponent<BoxElement<JorneyData>>().OnClose(data);
            Destroy(currentBox);
        }

        EventSystem.Instance.RemoveEventListener<Event_JorneyStateChanged>(OnJorneyTropeStarted);
    }

}
