using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BattleTropeBehaviour : TropeBehaviour
{
    public void begin(JorneyData jorney, BattleTropeData values)
    {
        DiaryManager.adventureLog(jorney, values.EncounterDescr.getText());
    }

    public bool ended(JorneyData jorney, BattleTropeData values)
    {
            //ограничивает скорость боя задержкой в один ход 
            if (jorney.Timer.turnPassed())
            {
                //если боевое событие закончено - не продолжать бой
                if (!jorney.Hero.isAlive() || !values.enemy.isAlive()) return true;

                //если после очередной атаки враг погиб 
                Debug.Log("Hero health: " + jorney.Hero.NativeHealth + " Enemy health: " + values.enemy.NativeHealth);
                if (values.enemy.dealDamage(jorney.Hero.NativePower))
                {
                    //пишем описание смерти в лог
                    DiaryManager.adventureLog(jorney, values.EndingDescr.getText());
                    //даем знать, что событие окончено
                    return true;

                }

                //TODO: добавить механику смерти героя
                if (jorney.Hero.dealDamage(values.enemy.NativePower))
                {
                    DiaryManager.adventureLog(jorney, "Герой пал в сражении с " + values.enemy.getName());
                    return true;
                }
            }

        return false;
    }
}
