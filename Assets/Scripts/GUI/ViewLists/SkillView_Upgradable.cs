using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SkillView_Upgradable : ViewElement<AttributePoint>
{
    private AttributePoint lastData;
    [SerializeField] private GameObject upgradeButton;
    [SerializeField] private GameObject degradeButton;
    public UnityEvent<AttributePoint> OnSkillPointUsedEvent;
    public UnityEvent<AttributePoint> OnSkillPointUnusedEvent;

    public TextMeshProUGUI attributeName;
    public TextMeshProUGUI value;
    
    public AttributePoint GetAttributePoint()
    {
        return lastData;
    }

    public override void updateView(AttributePoint data)
    {
        lastData = data;

        attributeName.text = data.attribute.getLName();
        value.text = (data.value+data.bonus).ToString();
    }

    public void setUpgradable(bool state)
    {
        upgradeButton.SetActive(state);
    }

    public void setDegradable(bool state)
    {
        degradeButton.SetActive(state);
    }

    public void OnUpgradeButtonClick()
    {
        if (OnSkillPointUsedEvent != null) OnSkillPointUsedEvent.Invoke(lastData);
    }

    public void OnDegradeButtonClick()
    {
        if (OnSkillPointUnusedEvent != null) OnSkillPointUnusedEvent.Invoke(lastData);
    }
}
