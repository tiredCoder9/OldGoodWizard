using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JorneysPageController : ViewListGroup<JorneyData, ViewElement_Selectable<JorneyData>>, Page
{
    private Dictionary<Id, JorneyData> jorneysLookup;
    //обьект такого типа всего один, при открытии в него передается JorneyData, которого он отрисовывает. Единовременно может быть много JorneyData, но Box для них только один.
    private BoxGroup<JorneyData> box;
    private GameObject boxObject;

    public GameObject boxPrefab;

    //задает родительскийный transform для box
    public Transform boxParentTransform;
    //задает канвас, на котором будет отрисовываться box
    public GameObject boxCanvasObject;



    public void updateJorneysList()
    {
        if(views==null) views = new List<ViewElement_Selectable<JorneyData>>();
        if(jorneysLookup==null) jorneysLookup = new Dictionary<Id, JorneyData>();
        if(box==null) createJorneyBox();

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



    protected override void createView()
    {
        GameObject viewObject = Instantiate(viewPrefab, viewsParentTransform);
        ViewElement_Selectable<JorneyData> view = viewObject.GetComponent<ViewElement_Selectable<JorneyData>>();
        view.OnClickEvent.AddListener(OnBoxOpen);
        views.Add(view);
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

    private void createJorneyBox()
    {

        //создаем обьект box'а
        boxObject = Instantiate(boxPrefab, boxParentTransform);
        box = boxObject.GetComponent<BoxGroup<JorneyData>>();

        if (box == null)
        {
            //префаб не содержит нужного компнента
            Debug.LogError("JORNEY PAGE CONTROLLER: invalid prefab");
            return;
        }
        
        //отправляем делегат, который вызовиться при попытке пользователя закрыть box (способ закрытия задается в самом обьекте)
        box.OnBoxClosed.AddListener(OnBoxClose);

        //поумолчанию все boxes скрыты и открываются только через интерфейс
        boxObject.SetActive(false);
    }




    public void OnBoxOpen(Id id)
    {
       if(!box.IsOpen) OpenBox(id);
    }

    public void OnBoxClose(JorneyData boxData)
    {
        CloseBox(boxData);
    }


    public void OpenBox(Id id)
    {

        boxCanvasObject.SetActive(true);
        boxObject.SetActive(true);

        box.OnOpen(jorneysLookup[id]);
    }

    public void CloseBox(JorneyData boxData)
    {
        box.OnClose(boxData);

        boxObject.SetActive(false);
        boxCanvasObject.SetActive(false);
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
    }
}
