using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LogDiaryGUI : MonoBehaviour
{
    public List<LogElement> logElements;
    public GameObject logElemPrefab;
    public Id jorneyID;

    private DiaryItem topDiaryItem;
    private Diary log;
    private JorneyData data;
    
    private void Start()
    {
        logElements = new List<LogElement>();
        ///////////ВРЕМЕННЫЙ КОД

        JorneyData data = JorneyDataManager.Instance.getJorneyDataByID(jorneyID);

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
        log = data.diary;
        topDiaryItem = log.getLast();
        
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
        return topDiaryItem != log.getLast(); ;
    }



    public void tryExtendLog()
    {
        if (log.getCount() > logElements.Count)
        {
            while (logElements.Count != log.getCount())
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
        for(int i=0; i<log.getCount(); i++)
        {
            logElements[i].setContent(log.Notes[i]);
        }

    }


    public void deleteLogGui()
    {
        Destroy(this.gameObject);
    }
}
