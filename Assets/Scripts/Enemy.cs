using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class Enemy : Entity
{
    //вычислить общую силу существа
    public int difficult { get { return (nativeHealth + nativePower)/2; } }

    public int getHealth() { return nativeHealth; }
    public int getPower() { return nativePower; }
    /// <summary>
    /// Возвращает копию существа с изначальными параметрами.
    /// </summary>
    /// <returns></returns>
    public Enemy getClone()
    {
        return Instantiate(this);
    }



    
}
