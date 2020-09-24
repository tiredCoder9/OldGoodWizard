using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TropeActions 
{
    public static void dealDamage(Hero _hero, int _damage)
    {
        _hero.dealDamage(_damage);
    }

    public static void healHealth(Hero _hero, int _health)
    {
        Debug.LogError("NOT IMPLEMENTED: heal health");
    }

    public static void giveItem(Hero _hero, Item _item)
    {
        Debug.LogError("NOT IMPLEMENTED: give item");
    }

    public static void pushTrope(Jorney _jorney, Trope trope) 
    {
        Debug.LogError("NOT IMPLEMENTED: trope pushed");
    }
}
