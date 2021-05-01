using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewBattlEncounter", menuName = "Content/TropeAssets/Battle/BattleEncounter")]
public class BattleEncounter : ScriptableObject
{
    public int MaxEnemiesCount=1;
    public int MinEnemiesCount=3;

    public EnemyBlueprint[] capableEnemies;

    public int meetDistance=-1;

    public AdventureTextPattern encounterDescription;
    public AdventureTextPattern endingDescription;

    public List<Enemy> GenerateEnemyEntities()
    {
        var enemiesCount = Random.Range(MinEnemiesCount, MaxEnemiesCount+1);
        List<Enemy> enemies = new List<Enemy>();

        for(int i=0; i<enemiesCount; i++)
        {
            enemies.Add(capableEnemies.getRandomElement().getClone());
        }
        return enemies;
    }
}
