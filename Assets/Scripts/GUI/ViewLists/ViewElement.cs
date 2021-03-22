using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ViewElement<T> : MonoBehaviour
{
    public abstract void updateView(T data);
}
