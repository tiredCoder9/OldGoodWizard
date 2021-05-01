using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BattleTropeBehaviour : TropeBehaviour
{
    public void begin(JorneyData jorney, BattleTropeData values)
    {
        DiaryManager.adventureLog(jorney, values.EncounterDescription);

        List<Character> c_enemies = new List<Character>();
        c_enemies.AddRange(values.enemies);

        values.battle = new Battle(jorney.Hero, c_enemies);
    }

    public bool ended(JorneyData jorney, BattleTropeData values)
    {
        //ограничивает скорость боя задержкой в один ход 
        if (jorney.Timer.turnPassed())
        {
            ////если боевое событие закончено - не продолжать бой
            //if (!jorney.Hero.isAlive() || !values.enemy.isAlive()) return true;

            ////если после очередной атаки враг погиб 
            //Debug.Log("Hero health: " + jorney.Hero.CurrentHealth + " Enemy health: " + values.enemy.CurrentHealth);
            //if (values.enemy.dealDamage(jorney.Hero.generateDamageValue()))
            //{

            //    //пишем описание смерти в лог
            //    DiaryManager.adventureLog(jorney, values.enemy.endingDescription.Text);

            //    jorney.Hero.LevelBehavior.addExperience(values.enemy.rewardExperience);
            //    DiaryManager.adventureLog(jorney, "Получено опыта: " + values.enemy.rewardExperience);



            //    //даем знать, что событие окончено
            //    values.IsEnded = true;
            //    return true;

            //}



            //if (jorney.Hero.dealDamage(values.enemy.generateDamageValue()))
            //{
            //    DiaryManager.adventureLog(jorney, "Герой пал в сражении с " + values.enemy.EntityName);
            //    return true;
            //}

            if (!values.isBattleEnded)
            {
                var battleTurnResult = values.battle.BattleUpdate(jorney.Timer);

                //Debug.Log("hero health -> " + jorney.Hero.CurrentHealth);
                //Debug.Log("enemy health -> " + values.enemies.CurrentHealth + " ->" + values.enemies.isAlive() + " or " + values.enemies.isSane());

                if (battleTurnResult != null)
                {

                    if (!battleTurnResult.IsheroDead)
                    {

                        if (battleTurnResult.IsheroWin)
                        {

                            DiaryManager.adventureLog(jorney, values.EndingDescription);

                            generateBattleEndResult(jorney, values);

                            values.isBattleEnded = true;
                            values.battleEndTime = jorney.Timer.innerTime;
                            values.OnBattleEnded?.Invoke(values.battleResult);
                        }
                    }
                    else
                    {
                        DiaryManager.adventureLog(jorney, "Герой пал в сражении с " + values.enemies[0].EntityName);
                        values.isBattleEnded = true;
                        values.battleEndTime = jorney.Timer.innerTime;
                        values.OnBattleEnded?.Invoke(null);
                    }
                }
            }
            else
            {
                return battleEndWaiting(jorney, values);
            }
        }

        return false;
    }


    private bool battleEndWaiting(JorneyData jorney, BattleTropeData values)
    {
        
        if(jorney.Timer.innerTime > values.battleEndTime + 10f)
        {
            values.IsEnded = true;
            return true;
        }
        return false;
    }

    private void generateBattleEndResult(JorneyData jorney, BattleTropeData values)
    {
        //TODO: добавить обработку группы врагов.
        //TODO: добавить обработку глобального мирового лута в зависимости от пройденного расстояния.

        int experience = 0;
        ItemList loot = new ItemList();

        foreach(var e in values.enemies)
        {
            experience += e.rewardExperience;
            loot.AddList(e.GenerateLoot(1));
        }


        jorney.Hero.LevelBehavior.addExperience(experience);
        jorney.AddLoot(loot);

        DiaryManager.adventureLog(jorney, "Получено опыта: " + experience);

        values.battleResult = new BattleEndResult(experience, loot);
    }
}
