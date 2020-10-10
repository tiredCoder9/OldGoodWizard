using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LogDiaryGUI : MonoBehaviour
{
    public List<LogElement> logElements;
    public GameObject logElemPrefab;
    public string jorneyID;

    private DiaryItem topDiaryItem;
    private List<DiaryItem> log;
    private JorneyData data;
    
    private void Start()
    {
        logElements = new List<LogElement>();
        ///////////ВРЕМЕННЫЙ КОД

        JorneyData data = JorneyDataManager.getJorneyDataByID(jorneyID);

        if (data != null)
        {
            startDiaryLog(data);
        }
        else
        { 
            deleteLogGui();
        }
    }

    private void startDiaryLog(JorneyData data)
    {
        log = data.diary.Notes;
        topDiaryItem = log.Last();
        updateLogGUI();

    }


    private void Update()
    {
        if (data == null)
        {
            if (logIsChanged())
            {
                updateLogGUI();
            }
        }
        else
        {
            print("GUI: Jorney with id " + jorneyID + " not found!");
            deleteLogGui();
        }

    }


    private bool logIsChanged()
    {
        return topDiaryItem != log.Last();
    }



    public void tryExtendLog()
    {
        if (log.Count > logElements.Count)
        {
            while (logElements.Count != log.Count)
            {
                GameObject _logObject = Instantiate(logElemPrefab, transform);
                var _logElement = _logObject.GetComponent<LogElement>();
                logElements.Add(_logElement);
            }
        }
    }

    private void updateLogGUI()
    {

        //создаем новые элементы интерфейса для каждой записи, если их не хватает.
        tryExtendLog();

        //изменяем содержание каждого элемента на записи из дневника
        for(int i=0; i<log.Count; i++)
        {
            logElements[i].setContent(log[i]);
        }

        topDiaryItem = log.Last();
    }


    public void deleteLogGui()
    {
        Destroy(this.gameObject);
    }
}
