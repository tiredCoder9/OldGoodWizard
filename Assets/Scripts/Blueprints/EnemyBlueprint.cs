using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class EnemyBlueprint : EntityBlueprint
{
    public int Difficult { get { return (nativeHealth + nativePower) / 2; } }

    public AdventureTextPattern encounterDescription;
    public AdventureTextPattern endingDescription;

    public ActorSkillsBlueprint skillsBlueprint;

    /// <summary>
    /// Возвращает копию существа с изначальными параметрами.
    /// </summary>
    /// <returns></returns>
    public Enemy getClone()
    {
        return new Enemy(this);
    }


}


