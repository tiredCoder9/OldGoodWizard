using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TestSave : ScriptableObject
{
    public int attack;
    public string desc;
    public long id;
    public List<TestItem> items;
    public Sprite sprite;

    public int testGet
    {
        get
        {
            return attack - (int)id;
        }
    }
}
