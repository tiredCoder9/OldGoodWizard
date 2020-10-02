using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LogDiaryGUI : MonoBehaviour
{
    public List<LogElement> logElements;
    public Jorney jorney;
    public GameObject logElemPrefab;
    private DiaryItem topDiaryItem;
    private List<DiaryItem> notes;
    private void Start()
    {
        logElements = new List<LogElement>();
        ///////////ВРЕМЕННЫЙ КОД
        startDiaryLog("2_jorney");
    }

    private void startDiaryLog(string logJorneyID)
    {
        //пытаемся получить обьект jorney от контроллера
        jorney = JorneysController.getJorneyComponentById(logJorneyID);
        //если обьект был найден - инициализируем для него интерфейс
        if (jorney != null)
        {
            createNotesGUI(jorney.values.diary.notes.Count);

            notes = jorney.values.diary.notes;
            topDiaryItem = notes[notes.Count - 1];

            updateLog();
        }
    }


    private void Update()
    {
        if (notes[notes.Count-1] != topDiaryItem)
        {
            updateLog();
            topDiaryItem = notes[notes.Count - 1];
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

    private void updateLog()
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
