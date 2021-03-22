using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGenerator : MonoBehaviour
{
    private string heroPortraitsPath= "Portraits/";

    public ActorSkillsBlueprint[] actorSkillsSets;

    public Hero CreateRandom()
    {
        Sprite portrait = loadRandomPortrait();
        string name = NameGenerator.generate(Character.Gender.male);

        ActorSkillsBlueprint actorPattern = actorSkillsSets.getRandomElement<ActorSkillsBlueprint>();

        string className = actorPattern.name;
        ActorSkills actor = actorPattern.getClone();
        actor.scatterSkillPoints_Random(Random.Range(10,5));

        LevelBehavior levelBehavior = new LevelBehavior(1, 100);

        Hero randomHero = new Hero(name, className, actor, levelBehavior, portrait);

        HeroDataManager.Instance.AddObject(randomHero);
        randomHero.save();
        return randomHero;
    }

    private Sprite loadRandomPortrait()
    {
        return Resources.LoadAll<Sprite>(heroPortraitsPath).getRandomElement<Sprite>();
    }


    
}
