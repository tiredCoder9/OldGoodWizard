using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DiaryDialog : DiaryItem
{
    private DialogueVariant[] variants;
    public DiaryDialog(long _time, string _text, DialogueVariant[] _variants)
    {
        this.text = _text;
        this.time = _time;
        this.variants = _variants;
    }

    //возвращает истину, если какой-то из вариантов выбран
    public bool isSelected()
    {
        return variants.Any(variant => variant.selected);
    }

    public DialogueVariant[] GetVariants()
    {
        return variants;
    }

    
}
