using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBoxElement : BoxElement<JorneyData>
{
    private Id boxId;

    public LogList log;


    public override void OnOpen(JorneyData data)
    {
        boxId = data.Id;
        EventSystem.Instance.AddEventListener<Event_DiaryChanged>(OnDiaryChanged);
        log.updateGroup(data.Diary.Notes);
    }


    public override void OnClose(JorneyData data)
    {
        EventSystem.Instance.RemoveEventListener<Event_DiaryChanged>(OnDiaryChanged);
    }


    public void OnDiaryChanged(Event_DiaryChanged e)
    {
        if (boxId == e.jorneyID)
        {
            log.updateGroup(e.diary.Notes);
        }
    }


}
