using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillUpgradeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.Instance.AddEventListener<GUIEvent_upgradeSkills>(OnActorSkillUpgraded);
    }

    private void OnActorSkillUpgraded(GUIEvent_upgradeSkills e)
    {
        if(e!=null && e.hero!=null && e.points != null)
        {
            int sum = e.points.Values.Sum(point => point);
            if(e.hero.State==Hero.HeroState.tower && e.hero.LevelBehavior.SkillPoints == sum)
            {
                spendSkillPoints(e.hero, e.points);
            }
        }
    }

    private void spendSkillPoints(Hero hero, Dictionary<BaseAttribute.AttributeType, int> points)
    {
        hero.levelUp(hero.LevelBehavior.LevelPoints, points);

        hero.save();
    }

}
