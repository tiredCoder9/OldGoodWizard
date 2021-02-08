using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class Entity : Identifyable
{
    [JsonProperty] [SerializeField] protected string entityName="PLACEHOLDER";
    [JsonProperty] [SerializeField] protected Id _id;



    [JsonIgnore] public string EntityName { get { return entityName; } }
    [JsonIgnore] public Id Id { get { return _id; } }


    public Entity() { }

    public Entity(Id id, string _name, int _power, int _health)
    {
        _id = id;
        entityName = _name;
    }

    /// <summary>
    /// Метод наносит сущности урон, если урон оказался смертельным, то метод возвращает True.
    /// </summary>
}

