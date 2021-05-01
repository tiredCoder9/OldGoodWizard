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
     
   


        BattleEncounter battleEncounter = jorney.MainModule.encounters.getRandomElement();
        List<Enemy> enemies = battleEncounter.GenerateEnemyEntities();
        string startDescrp = battleEncounter.encounterDescription.GenerateText(enemies.ToArray(), jorney);
        string endDesccrp = battleEncounter.endingDescription.GenerateText(enemies.ToArray(), jorney);


        BattleTropeData data = new BattleTropeData(enemies, null, startDescrp, endDesccrp, false);
        BattleTropeBehaviour behaviour = new BattleTropeBehaviour();

        BattleTropeInstance battle = new BattleTropeInstance(behaviour, data, new Id(jorney.Hero.Id.get() + "trope"));

        TropeDataManager.Instance.addObject(battle);

        return battle;
    }


    private void generateAdventure()
    {

    }

}
