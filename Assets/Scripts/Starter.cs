using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    //инициализирует работу всех основных систем игры
    private void Awake()
    {

        
        EnemyStore.Instance.LoadStore();
        AdventureTextPatternStore.Instance.LoadStore();
        AdventureModuleStore.Instance.LoadStore();


        HeroDataManager.Instance.LoadData();
        TropeDataManager.Instance.LoadData();
        JorneyDataManager.Instance.LoadData();

    }

}
