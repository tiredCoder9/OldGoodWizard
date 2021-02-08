using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableVariable<T> : ScriptableObject
{
    [SerializeField] protected T value;
}
