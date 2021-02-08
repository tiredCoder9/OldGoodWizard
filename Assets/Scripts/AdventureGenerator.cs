using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureGenerator : MonoBehaviour
{



    public TropeInstance getNextTrope(JorneyData jorney)
    {
        return generateBattleTrope(jorney);
    }


    private TropeInstance generateBattleTrope(JorneyData jorney)
    {
        Enemy enemy = jorney.MainModule.enemies[Random.Range(0, jorney.MainModule.enemies.Length)].getClone();

        BattleTropeData data = new BattleTropeData(enemy.Id, enemy);
        BattleTropeBehaviour behaviour = new BattleTropeBehaviour();

        BattleTropeInstance battle = new BattleTropeInstance(behaviour, data, new Id(jorney.Hero.Id.get() + "trope"));

        TropeDataManager.Instance.addObject(battle);

        return battle;
    }


    private void generateAdventure()
    {

    }

}
