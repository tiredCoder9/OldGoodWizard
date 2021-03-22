using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillView : ViewElement<AttributePoint>
{
    public TextMeshProUGUI attributeName;
    public TextMeshProUGUI value;

    public override void updateView(AttributePoint data)
    {
        attributeName.text = data.attribute.getLName();
        value.text = data.value.ToString();
    }
}
