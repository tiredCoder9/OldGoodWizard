using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hero
{

    [SerializeField]
    private Sprite portrait;
    public long id;
    [SerializeField]
    protected string entityName;
    [SerializeField]

    protected int nativePower = 0;
    [SerializeField]
    protected int nativeHealth = 0; 
    [SerializeField]
    private int nativeSanity = 0;

    //TODO: добавить учет предметов
    public int getHealth() { return nativeHealth; }
    public int getPower() { return nativePower; }

    public void setHealth(int _health) { nativeHealth = _health; }
    public void setPower(int _power) { nativePower = _power; }
    public string getName() { return entityName; }
    public void setName(string _name) { entityName = _name; }


    /// <summary>
    /// Метод наносит сущности урон, если урон оказался смертельным, то метод возвращает True.
    /// </summary>
    public bool dealDamage(int _damage)
    {

        nativeHealth -= _damage;
        if (nativeHealth <= 0)
        {
            nativeHealth = 0;
            return true;
        }
        return false;

    }

    public bool isAlive() { return nativeHealth > 0; }


}
