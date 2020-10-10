﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BattleTrope", menuName = "Battle trope")]
public class BattleTrope : Trope
{

    public Enemy enemy;
    [TextArea]
    public string endDescription;

    public override bool ended(JorneyData _jorney)
    {
        //ограничивает скорость боя задержкой в один ход 
        if (_jorney.timer.turnPassed())
        {
            
            //если боевое событие закончено - не продолжать бой
            if (!_jorney.hero.isAlive() || !enemy.isAlive()) return true;


            //если после очередной атаки враг погиб 
            Debug.Log("Hero health: " + _jorney.hero.getHealth() + " Enemy health: " + enemy.getHealth());
            if (enemy.dealDamage(_jorney.hero.getPower()))
            {
                //пишем описание смерти в лог
                DiaryManager.adventureLog(_jorney, endDescription);
                //даем знать, что событие окончено
                return true;

            }

            //TODO: добавить механику смерти героя
            if (_jorney.hero.dealDamage(enemy.getPower()))
            {
                DiaryManager.adventureLog(_jorney, "Герой пал в сражении с " + enemy.getName());
                return true;

            }
        }


        return false;


    }



    public override void begin(JorneyData _jorney)
    {

       
        DiaryManager.adventureLog(_jorney ,description);

    }

    public override bool isPossible(JorneyData _jorney)
    {
        return true;
    }


    public override Trope getCopy()
    {
        BattleTrope trope = Instantiate(this);
        trope.enemy = Instantiate(enemy);
        return trope;
    }


}
