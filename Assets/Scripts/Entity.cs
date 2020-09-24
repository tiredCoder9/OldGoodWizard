using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : ScriptableObject
{
    [SerializeField]
    protected string entityName;
    [SerializeField]
    protected int nativePower = 1;
    [SerializeField]
    protected int nativeHealth = 3;

    /// <summary>
    /// Метод наносит сущности урон, если урон оказался смертельным, то метод возвращает True.
    /// </summary>
    public bool dealDamage(int _damage)
    {

        nativeHealth -= _damage;
        if (nativeHealth <= 0)
        {
            nativeHealth = 0;
            return true;
        }
        return false;
        
    }

    public bool isAlive() { return nativeHealth > 0; }

    public string getName() { return entityName; }
}
