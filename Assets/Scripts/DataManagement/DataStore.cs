using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;



public class DataStore<T, D> : Singletone<T> where T :MonoBehaviour where D: ScriptableObject, Identifyable
{
    protected Dictionary<Id, D> accessDatabase;
    [SerializeField]
    protected List<D> collection;

    private void OnValidate()
    {
        updateCollection();
    }

    public void LoadStore()
    {
        updateCollection();
    }


    private void updateCollection()
    {
        if (collection != null)
        {
            accessDatabase = new Dictionary<Id, D>();
            foreach (var elem in collection)
            {
                if (elem!=null && !accessDatabase.ContainsKey(elem.Id)) accessDatabase.Add(elem.Id, elem);
            }
        }
    }

    public D getObject(Id id)
    {
        if (accessDatabase.ContainsKey(id))
        {
            return accessDatabase[id];
        }
        return null;
    }

    public List<D> getCollection()
    {
        return collection;
    }

}
