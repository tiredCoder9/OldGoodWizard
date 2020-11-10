using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBlueprint : ScriptableObject, Identifyable
{
    [SerializeField] protected string entityName;
    [SerializeField] protected int nativePower = 1;
    [SerializeField] protected int nativeHealth = 3;
    [SerializeField] private Id _id;

    public string EntityName { get { return entityName; } }
    public int NativePower {get{return nativePower; } }
    public int NativeHealth { get { return nativeHealth; } }
    public Id Id { get { return _id; } }

}


