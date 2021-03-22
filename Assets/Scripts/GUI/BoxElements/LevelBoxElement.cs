using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelBoxElement : BoxElement<Hero>
{
    public ScaleBar scaleBar;
    public TextMeshProUGUI levelText;
    public string level_text_prefix= "Уровень - ";

    public override void OnClose(Hero data)
    {
        
    }

    public override void OnOpen(Hero data)
    {
        int level = data.LevelBehavior.CurrentLevel;
        long currentExoerience = data.LevelBehavior.CurrentExperience;
        long requiredExperience = data.LevelBehavior.RequiredExperience;

        scaleBar.updateScale(currentExoerience, requiredExperience);
        levelText.text = level_text_prefix + level;
    }
}
