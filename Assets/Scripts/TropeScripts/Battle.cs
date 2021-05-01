using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;

public class Battle 
{
    [JsonIgnore] private Character hero;
    [JsonIgnore] private List<Character> enemies;
    [JsonIgnore] public System.Action<Character, Character> OnAttack;
    [JsonIgnore] public System.Action OnBattleEnd;

    [JsonProperty] private float battleTurnDelay = 1f;
    [JsonProperty] private float lastTurnTime;
    [JsonProperty] public bool IsEnemiesAttacked;
    [JsonProperty] public int lastEnemyPointer=0;

    public Battle(Character hero, List<Character> enemies)
    {
        this.hero = hero;
        this.enemies = enemies;
    }


    public BattleTurnResult BattleUpdate(Timer timer)
    {
        if (timer.turnPassed())
        {
            return Turn();
        }
        return null;
    }

    

    private BattleTurnResult Turn()
    {
        if (!IsEnemiesAttacked)
        {
            for(int i=0; i<enemies.Count; i++)
            {
                if (i >= lastEnemyPointer)
                {
                    Debug.Log(enemies[i].EntityName + " attacks! -> is alive? " + enemies[i].isAlive());
                    if (enemies[i].isAlive() && enemies[i].isSane())
                    {
                        enemies[i].Attack(hero);
                        lastEnemyPointer++;
                        if (lastEnemyPointer >= enemies.Count) IsEnemiesAttacked = true;
                        
                        return new BattleTurnResult(!hero.isAlive(), false, enemies[i], hero, "temp attacks", "temp defends");
                    }
                    else
                    {
                        lastEnemyPointer++;
                        if (lastEnemyPointer >= enemies.Count) IsEnemiesAttacked = true;
                    }
                    
                    Debug.Log(lastEnemyPointer);
                }
            }
        }
        else
        {
            if (hero.isAlive())
            {
                var enemy = enemies.Find(e => e.isAlive());
                if (enemy != null)
                {
                    hero.Attack(enemy);
                    IsEnemiesAttacked = false;
                    lastEnemyPointer = 0;
                    bool someOneAlive = enemies.Any(e => e.isAlive());
                    return new BattleTurnResult(!hero.isAlive(), !someOneAlive, hero, enemy, "temp attack", "temp defend");
                }
            }
        }

        return null;
    }

    public void SetValues(Character hero, List<Character> enemies)
    {
        this.hero = hero;
        this.enemies = enemies;
    }
}

public class BattleTurnResult
{
    private bool isheroDead;
    private bool isheroWin;

    private Character attacker;
    private Character defender;

    private string attackerActionDescrp;
    private string defenderActionDescrp;

    public bool IsheroDead { get => isheroDead;}
    public Character Attacker { get => attacker; }
    public Character Defender { get => defender; }
    public string AttackerActionDescrp { get => attackerActionDescrp;}
    public string DefenderActionDescrp { get => defenderActionDescrp;}
    public bool IsheroWin { get => isheroWin; set => isheroWin = value; }

    public BattleTurnResult(bool isheroDead, bool isheroWin, Character attacker, Character defender, string attackerActionDescrp, string defenderActionDescrp)
    {
        this.isheroDead = isheroDead;
        this.isheroWin = isheroWin;
        this.attacker = attacker;
        this.defender = defender;
        this.attackerActionDescrp = attackerActionDescrp;
        this.defenderActionDescrp = defenderActionDescrp;
    }
}
