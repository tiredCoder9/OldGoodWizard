using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpecialTrope : Trope
{
    [SerializeField]
    private DiaryDialog dialog;

    public override void begin(JorneyData jorney)
    {
        base.begin(jorney);
        DiaryManager.adventureLog(jorney, dialog);
    }

    //проверяем выбран ли один из вариантов диалога
    public override bool ended(JorneyData jorney)
    {
        var selectedVariant = dialog.getSelectedOrNull();
        if (selectedVariant != null)
        {
            takeVariant(selectedVariant, jorney);
            return true;
        }

        return false;
    }

    public void takeVariant(DialogueVariant variant, JorneyData jorney)
    {
        variant.executeActions();
        //TODO: когда-нибудь придеться это переписать...
        
    }

}
