using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JorneysPageController : SelectorBoxList<JorneyData, ViewElement_Selectable<JorneyData>>, Page
{
    private Dictionary<Id, JorneyData> jorneysLookup;
    //обьект такого типа всего один, при открытии в него передается JorneyData, которого он отрисовывает. Единовременно может быть много JorneyData, но Box для них только один.




    public void updateJorneysList()
    {
        if(views==null) views = new List<ViewElement_Selectable<JorneyData>>();
        if(jorneysLookup==null) jorneysLookup = new Dictionary<Id, JorneyData>();

        List<JorneyData> jorneys = JorneyDataManager.Instance.GetJorneys();
        updateGroup(jorneys);
    }



    public override void updateGroup(List<JorneyData> targetList)
    {
        if (jorneysLookup.Count == targetList.Count) return;

        jorneysLookup.Clear();
        foreach(var elem in targetList)
        {
            jorneysLookup.Add(elem.Id, elem);
        }

        if (views.Count != targetList.Count)
        {
            resizeGroup(targetList);
        }


        for(int i = 0; i<views.Count; i++)
        {
            handleElement(targetList[i], views[i]);
        }

    }




    //новый jorney инициализирован, обрабатываем его 
    public void OnJorneyInitialized(Event_JorneyInitialized e)
    {
        updateJorneysList();
    }


    public void OnJorneyFinished(GUIEvent_finishJorney e)
    {
        updateJorneysList();
    }

    public void show()
    {
        updateJorneysList();
        //подписываемся на событие - появление нового инициализированного Jorney
        EventSystem.Instance.AddEventListener<Event_JorneyInitialized>(OnJorneyInitialized);
        EventSystem.Instance.AddEventListener<GUIEvent_finishJorney>(OnJorneyFinished);
    }

    public void hide()
    {
        EventSystem.Instance.RemoveEventListener<Event_JorneyInitialized>(OnJorneyInitialized);
        EventSystem.Instance.RemoveEventListener<GUIEvent_finishJorney>(OnJorneyFinished);

        if (currentBox != null)
        {
            closeBox();
        }
    }

    protected override void onViewClicked(Id id)
    {
        openBox(jorneysLookup[id]);
    }
}
