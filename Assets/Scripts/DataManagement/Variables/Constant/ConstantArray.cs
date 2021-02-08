using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantArray<T> : ScriptableObject
{
    [SerializeField] private T[] collection;
    public T[] Collection { get { return collection; } }
}
