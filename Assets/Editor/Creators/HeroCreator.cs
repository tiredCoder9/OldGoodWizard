using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HeroCreator : MonoBehaviour
{   
    [SerializeField]
    public Hero hero;

    //TODO: сделать нормальное создание героя с контролем за уникальностью ID
    public bool createHero()
    {
        string jsonSave = JsonUtility.ToJson(hero);
        if(File.Exists(HeroDataManager.path.ToString() + "/" + hero.id + ".hr"))
        {
            Debug.LogError("HERO CREATOR: hero already exist. Creating new hero with id " + hero.id + " has been stopped");
            return false;
        }
        File.WriteAllText(HeroDataManager.path.ToString() + "/" + hero.id + ".hr", jsonSave);
        return true;
    }
}
