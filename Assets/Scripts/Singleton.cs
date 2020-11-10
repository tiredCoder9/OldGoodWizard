using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Singletone<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T _Instance;

    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<T>();

                if (_Instance == null)
                {
                    var obj = new GameObject("[SINGLETON] " + typeof(T).Name);
                    _Instance = obj.AddComponent<T>();
                }
            }


            return _Instance;
        }
    }
}
