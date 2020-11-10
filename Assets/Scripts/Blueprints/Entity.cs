using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class Entity : Identifyable
{
    [JsonProperty] [SerializeField] protected string entityName;
    [JsonProperty] [SerializeField] protected int nativePower = 1;
    [JsonProperty] [SerializeField] protected int nativeHealth = 3;
    [JsonProperty] [SerializeField] protected Id _id;

    [JsonIgnore] public string EntityName { get { return entityName; } }
    [JsonIgnore] public int NativePower { get { return nativePower; } }
    [JsonIgnore] public int NativeHealth { get { return nativeHealth; } }
    [JsonIgnore] public Id Id { get { return _id; } }

    public Entity() { }

    public Entity(Id id, string _name, int _power, int _health)
    {
        _id = id;
        entityName = _name;
        nativeHealth = _health;
        nativePower = _power;
    }

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

