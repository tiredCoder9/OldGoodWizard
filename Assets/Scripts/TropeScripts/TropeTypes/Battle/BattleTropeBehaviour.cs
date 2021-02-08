using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BattleTropeBehaviour : TropeBehaviour
{
    public void begin(JorneyData jorney, BattleTropeData values)
    {
        DiaryManager.adventureLog(jorney, values.enemy.encounterDescription.Text);
    }

    public bool ended(JorneyData jorney, BattleTropeData values)
    {
            //ограничивает скорость боя задержкой в один ход 
            if (jorney.Timer.turnPassed())
            {
                //если боевое событие закончено - не продолжать бой
                if (!jorney.Hero.isAlive() || !values.enemy.isAlive()) return true;

                //если после очередной атаки враг погиб 
                Debug.Log("Hero health: " + jorney.Hero.CurrentHealth + " Enemy health: " + values.enemy.CurrentHealth);
                if (values.enemy.dealDamage(jorney.Hero.generateDamageValue()))
                {
                    //пишем описание смерти в лог
                    DiaryManager.adventureLog(jorney, values.enemy.endingDescription.Text);
                    //даем знать, что событие окончено
                    return true;

                }



                if (jorney.Hero.dealDamage(values.enemy.generateDamageValue()))
                {
                    DiaryManager.adventureLog(jorney, "Герой пал в сражении с " + values.enemy.EntityName);
                    return true;
                }
            }

        return false;
    }
}
