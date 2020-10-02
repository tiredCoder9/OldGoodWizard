using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "Trope", menuName = "Trope")]
public class Trope : ScriptableObject
{
    //решить проблему с генерацией случайных событий. ScriptableObject нельзя создавать как обьекты прямо в коде, придеться использовать один заготовленный троп, но изменять в нем значения
    [SerializeField]
    private string TropeName;
    

    [SerializeField]
    public long id;

    [TextArea, SerializeField]
    protected string description;

    public virtual bool isPossible(JorneyData jorney) { return true; }

    public virtual void begin(JorneyData jorney){  DiaryManager.adventureLog(jorney, description);  }

    public virtual bool end(JorneyData jorney) { return true; }
    
}
