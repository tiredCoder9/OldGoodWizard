using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsBoxElement : BoxElement<Hero>
{
    public SkillsViewList skillList;

    public override void OnClose(Hero data)
    {
        skillList.clearList(data);
    }

    public override void OnOpen(Hero data)
    {
        skillList.resetList(data);
    }
}
