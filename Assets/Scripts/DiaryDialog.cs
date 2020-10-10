using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class DiaryDialog : DiaryItem
{

    public bool IsAnySelected=false;

    [SerializeField]
    private DialogueVariant[] variants;


    //возвращает истину, если какой-то из вариантов выбран
    public DialogueVariant getSelectedOrNull()
    {
        
        foreach(var variant in variants)
        {
            if (variant.IsSelected)
            {
                IsAnySelected = true;
                return variant;
            }
        }
        return null;
    }



    public DialogueVariant[] GetVariants()
    {
        return variants;
    }





    
}
