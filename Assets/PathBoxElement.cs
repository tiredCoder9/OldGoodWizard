using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PathBoxElement : BoxElement<JorneyData>
{
    public TextMeshProUGUI distanceText;
    public Id boxId;


    public override void OnOpen(JorneyData data)
    {
        boxId = data.Id;
        updateElement(data.Distance);
        EventSystem.Instance.AddEventListener<Event_JorneyDistanceChanged>(OnDistanceChanged);
    }

    public override void OnClose(JorneyData data)
    {
        EventSystem.Instance.RemoveEventListener<Event_JorneyDistanceChanged>(OnDistanceChanged);
    }


    public void OnDistanceChanged(Event_JorneyDistanceChanged e)
    {
        if (e.jorneyID == boxId)
        {
            updateElement(e.distance);
        }
    }


    public void updateElement(float _distance)
    {
        distanceText.text = (int)(_distance * 10) + " m";
    }


}
