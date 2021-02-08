using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantVariable<T> : ScriptableVariable<T>
{
    public T Value { get { return value; } }
}
