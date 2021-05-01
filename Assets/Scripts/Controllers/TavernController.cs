using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernController : MonoBehaviour
{
    public HeroGenerator generator;

    [Header("Constants")]
    public ConstantDouble ChangeHeroesTimeDelay;
    public ConstantInteger MaxHeroesSetCount;

    [Header("Persistent Data")]
    public PersistentVariableDouble lastTavernUpdateTime;
    public PlayerMoney money;


    public void Start()
    {

        if (GameManager._GLOBAL_TIME_ > lastTavernUpdateTime.getValue() + ChangeHeroesTimeDelay.Value)
        {
            Debug.Log("TAVERN CONTROLLER: tavern heroes set update - set is planed to -"+ (lastTavernUpdateTime.getValue() + ChangeHeroesTimeDelay.Value+" - now is -" + GameManager._GLOBAL_TIME_));
            lastTavernUpdateTime.setValue(GameManager._GLOBAL_TIME_);
            updateHeroesSet();
            Debug.Log("TAVERN CONTROLLER: next setup change in - "+ (lastTavernUpdateTime.getValue() + ChangeHeroesTimeDelay.Value));
        }

        EventSystem.Instance.AddEventListener<GUIEvent_hireHero>(OnHireHero);
    }

    public void updateHeroesSet()
    {
        List<Hero> previousSet = HeroDataManager.Instance.GetHeroesByState(Hero.HeroState.tavern);

        foreach (Hero hero in previousSet)
        {
            hero.delete();
        }

        for(int i=0; i< MaxHeroesSetCount.Value; i++)
        {
            generator.CreateRandom();
        }
    }

   

    public void OnHireHero(GUIEvent_hireHero e)
    {
        if (e!=null && e.heroToHire.IsInitialized)
        {
            Hero hero = HeroDataManager.Instance.getHeroByID(e.heroToHire);

            if(hero!=null && hero.State == Hero.HeroState.tavern)
            {
                if (hero.getPrice()<=money.getValue())
                {
                    money.setValue(money.getValue() - hero.getPrice());
                    hero.State = Hero.HeroState.tower;
                    hero.save();
                }
            }
        }
    }

  
}
