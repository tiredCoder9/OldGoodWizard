using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsBoxElement_Upgradable : BoxElement<Hero>
{
    public SkillsViewList_Upgradable skillList;

    public override void OnClose(Hero data)
    {
        skillList.clearList(data.ActorSkills);
    }

    public override void OnOpen(Hero data)
    {
        skillList.resetList(data);
    }
}
