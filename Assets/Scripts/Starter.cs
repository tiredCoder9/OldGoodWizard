using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    //инициализирует работу всех основных систем игры
    public void Awake()
    {
        Debug.Log("GAME MANAGER: start time is - " + GameManager._GLOBAL_TIME_);

        PersistentVariablesDataManager.Instance.LoadData();

        EnemyStore.Instance.LoadStore();
        AdventureTextPatternStore.Instance.LoadStore();
        AdventureModuleStore.Instance.LoadStore();
        
        HeroDataManager.Instance.LoadData();
        TropeDataManager.Instance.LoadData();
        JorneyDataManager.Instance.LoadData();

        PersistentControllersSystem.Instance.LoadData();

    }

}
