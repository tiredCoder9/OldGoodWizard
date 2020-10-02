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
    public bool selected = false;
    public TextAsset actions;

    public void select()
    {
        selected = true;
        executeActions();
    }


    private void executeActions()
    {

    }
}
