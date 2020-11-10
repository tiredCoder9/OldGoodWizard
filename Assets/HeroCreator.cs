using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HeroCreator : MonoBehaviour
{   
    [SerializeField]
    public Hero hero;

    //TODO: сделать нормальное создание героя с контролем за уникальностью ID
    public void createHero()
    {

        FileNameFormat format = new FileNameFormat("dt_", string.Empty);


        if (!Directory.Exists(Application.persistentDataPath + "/" + typeof(Hero).Name + "s"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/" + typeof(Hero).Name + "s");
        }

        JsonTool.save<Hero>(hero, hero.Id.get(), Application.persistentDataPath + "/" + typeof(Hero).Name + "s", new FileNameFormat("dt_", string.Empty, typeof(Hero).Name));


    }
}
