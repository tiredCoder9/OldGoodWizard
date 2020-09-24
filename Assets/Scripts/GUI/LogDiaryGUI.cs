using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogDiaryGUI : MonoBehaviour
{
    public List<LogElement> logElements;
    public Jorney jorney;
    public GameObject logElemPrefab;
    
    void Start()
    {
        logElements = new List<LogElement>();
        ///////////ВРЕМЕННЫЙ КОД
        startDiaryLog("2_jorney");
    }

    void startDiaryLog(string logJorneyID)
    {
        //пытаемся получить обьект jorney от контроллера
        jorney = JorneysController.getJorneyComponentById(logJorneyID);
        //если обьект был найден - инициализируем для него интерфейс
        if (jorney != null)
        {
            jorney.OnJorneyTropeTick += updateLog;


            print(jorney.values.diary.notes);
            createNotesGUI(jorney.values.diary.notes.Count);
            updateLog();
        }
    }

    public void createNotesGUI(int count)
    {
        if (count > logElements.Count)
        {
            while (logElements.Count != count)
            {
                GameObject _logObject = Instantiate(logElemPrefab, transform);
                var _logElement = _logObject.GetComponent<LogElement>();
                logElements.Add(_logElement);
            }
        }
    }

    void updateLog()
    {
        //получаем текущие записи из дневника
        List<DiaryItem> _notes = jorney.values.diary.notes;
        //создаем новые элементы интерфейса для каждой записи, если их не хватает.
        createNotesGUI(_notes.Count);
        //изменяем содержание каждого элемента на записи из дневника
        for(int i=0; i<_notes.Count; i++)
        {
            logElements[i].setContent(_notes[i]);
        }
          
    }



}
