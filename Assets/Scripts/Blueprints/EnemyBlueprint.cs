using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class EnemyBlueprint : EntityBlueprint
{
    public int Difficult { get { return (nativeHealth + nativePower) / 2; } }

    public ActorSkillsBlueprint skillsBlueprint;

    [SerializeField]
    public ItemList enemyLoot;

    /// <summary>
    /// Возвращает копию существа с изначальными параметрами.
    /// </summary>
    /// <returns></returns>
    public Enemy getClone()
    {
        return new Enemy(this);
    }


}


