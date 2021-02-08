using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyExtensions
{
    public static T getRandomElement<T>(this T[] elements)
    {
        return elements[Random.Range(0, elements.Length)];
    }


    public static T getRandomElement<T>(this List<T> elements)
    {
        return elements[Random.Range(0, elements.Count)];
    }
}
