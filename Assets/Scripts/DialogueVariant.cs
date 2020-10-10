using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
[System.Serializable]
public class DialogueVariant
{
    public string text;
    public string actionResultText;
    public bool IsSelected { get { return selected; } }

    private bool selected = false;
    private TextAsset actions;

    public void select()
    {
        selected = true;
    }


    public void executeActions()
    {
        //TODO: добавить событию уникальное поведение
    }
}
