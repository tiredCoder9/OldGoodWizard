using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;


public class SkillsViewList_Upgradable : ViewListGroup<AttributePoint, SkillView_Upgradable>
{
    
    private Dictionary<BaseAttribute.AttributeType, AttributePoint> skillValues;
    private Hero lastData;


    //ui elements
    public Button spendSkillPointsButton;
    public string skillPointsTextPrefix = "Очки навыков1: ";
    public TextMeshProUGUI skillPointsValue;


    public int UsedSkillPoints
    {
        get { return skillValues.Values.Sum(attr => attr.bonus); }
    }

    private int usedSkillPoints_calculated;

    public void resetList(Hero data)
    {
        lastData = data;
        skillValues = new Dictionary<BaseAttribute.AttributeType, AttributePoint>();

        var skills = lastData.ActorSkills.SkillAttributes;

        foreach(SkillAttribute skill in skills)
        {
            skillValues.Add(skill.type, new AttributePoint(skill.getFinalValue(lastData.ActorSkills), 0, skill));
        }

        updateList();
    }


    public void clearList(ActorSkills actor)
    {
        lastData = null;
        skillValues.Clear();
    }

    private void OnSkillPointUsed(AttributePoint attributePoint)
    {
        if (lastData != null)
        {
            var attribute = attributePoint.attribute;
            if (!lastData.ActorSkills.skillIsPumped(attribute.type, attributePoint.bonus))
            {
                var a = skillValues[attribute.type];
                skillValues[attribute.type] = new AttributePoint(a.value, a.bonus + 1, a.attribute);
            }
            updateList();
        }
    }

    protected override void handleElement(AttributePoint data, SkillView_Upgradable viewElement)
    {
        if (lastData != null)
        {
            if(lastData.ActorSkills.skillIsPumped( data.attribute.type, data.bonus) || usedSkillPoints_calculated >= lastData.LevelBehavior.SkillPoints)
            {
                viewElement.setUpgradable(false);
            }
            else
            {
                viewElement.setUpgradable(true);
            }

            viewElement.setDegradable(data.bonus > 0);

            viewElement.updateView(data);
        }
    }

    protected override void createView()
    {
        GameObject viewObject = Instantiate(viewPrefab, viewsParentTransform);
        var view = viewObject.GetComponent<SkillView_Upgradable>();
        view.OnSkillPointUsedEvent.AddListener(OnSkillPointUsed);
        view.OnSkillPointUnusedEvent.AddListener(OnSkillPointUnused);
        views.Add(view);
    }

    public void OnSpendSkillPointsButtonClick()
    {
        if (lastData != null && UsedSkillPoints==lastData.LevelBehavior.SkillPoints)
        {
            if (lastData.State == Hero.HeroState.tower)
            {
                Dictionary<BaseAttribute.AttributeType, int> usedPoints = new Dictionary<BaseAttribute.AttributeType, int>();

                foreach(var bonus in skillValues)
                {
                    usedPoints.Add(bonus.Value.attribute.type, bonus.Value.bonus);
                }

                EventSystem.Instance.Raise(new GUIEvent_upgradeSkills(lastData, usedPoints));
            }
        }
        resetList(lastData);
    }

    private void updateSubElements(long usedPoints, long allPoints)
    {
        skillPointsValue.text = skillPointsTextPrefix + (allPoints-usedPoints);
        spendSkillPointsButton.interactable = (usedPoints == allPoints && allPoints>0);
    }


    private void updateList()
    {
        usedSkillPoints_calculated = UsedSkillPoints;
        updateGroup(skillValues.Values.ToList());
        updateSubElements(usedSkillPoints_calculated, lastData.LevelBehavior.SkillPoints);
    }

    private void OnSkillPointUnused(AttributePoint attributePoint)
    {
        if (lastData != null)
        {
            if (attributePoint.bonus > 0)
            {
                var a = skillValues[attributePoint.attribute.type];
                skillValues[attributePoint.attribute.type] = new AttributePoint(a.value, a.bonus-1 ,a.attribute);
            }

            updateList();
        }
    }

}
