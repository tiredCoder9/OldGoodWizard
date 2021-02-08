using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class HeroDataManager : Singletone<HeroDataManager>, IDataManager
{
    private ContentLoader<Hero> contentLoader;

    [ReadOnly][SerializeField] private List<Hero> loadedHeroes;

    private HeroDataManager()
    {
        contentLoader = new ContentLoader<Hero>();
    }


    public void LoadData()
    {
        contentLoader.Initialize();

        loadedHeroes = contentLoader.getObjectsList();
    }

    public void saveHeroState(Id _id)
    {
        contentLoader.saveObject(_id);
    }
     
    public void loadHeroState(Id _id)
    {
        //TODO: реализовать
    }


     public Hero getHeroByID(Id _id)
    {
        return contentLoader.getObject(_id);
    }

    /// <summary>
    /// Add new hero object to system and try to save it in the files, it allows to save and load hero state in the future
    /// </summary>
    /// <returns></returns>
    public void AddObject(Hero hero)
    {
        contentLoader.AddObject(hero);
    }

    public List<Hero> getObjects()
    {
        return contentLoader.getObjectsList();
    }

    public List<Hero> GetHeroesByState(Hero.HeroState _state)
    {
        return contentLoader.getObjectsList().FindAll(hero => hero.State == _state);
    }


    public Id generateGUID()
    {
        return contentLoader.generateUniqueID();
    }

    public void deleteObject(Id id)
    {
        if (contentLoader.containsObject(id))
        {
            contentLoader.deleteObject(id);
        }
    }


}
