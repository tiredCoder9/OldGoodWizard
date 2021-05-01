using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleTropeBox : TropeInstanceView
{ 
    public Transform enemiesViewsContainer;
    public Transform heroViewContainer;

    public GameObject characterViewPrefab;
    public GameObject endBattleMessage;


    List<BattleEntityView> enemiesViews;
    BattleEntityView heroView;

    [SerializeField]
    private ItemGrid itemsGrid;
    [SerializeField]
    private TextMeshProUGUI experience;

    private BattleTropeInstance currentTrope;
    private Battle currentBattle;


    public override void OnOpen(JorneyData data)
    {
        CreateEntities(data);
        
    }

    public override void OnClose(JorneyData data)
    {
        DestroyEntities(data);
    }

    private void CreateEntities(JorneyData data)
    {
        if (data.CurrentTrope is BattleTropeInstance)
        {
            currentTrope = (BattleTropeInstance)data.CurrentTrope;

            //todo: вынести
            currentTrope.getData().OnBattleEnded += ShowEndBattleMessage;
            if (currentTrope.getData().isBattleEnded) ShowEndBattleMessage(currentTrope.getData().battleResult);

            heroView = Instantiate(characterViewPrefab, heroViewContainer).GetComponent<BattleEntityView>();
            heroView.SetCharacter(data.Hero);

            enemiesViews = new List<BattleEntityView>();
            foreach (var enemy in currentTrope.getData().getEnemies())
            {
                BattleEntityView enemyView = Instantiate(characterViewPrefab, enemiesViewsContainer).GetComponent<BattleEntityView>();
                enemyView.SetCharacter(enemy, -1);
                enemiesViews.Add(enemyView);
            }

            currentBattle= currentTrope.getData().battle;
        }
    }

    private void DestroyEntities(JorneyData data)
    {
        //todo: вынести

        if(currentTrope!=null) currentTrope.getData().OnBattleEnded -= ShowEndBattleMessage;

        if (heroView != null)
        {
            heroView.ClearCharacter();
            Destroy(heroView);
        }
        heroView = null;

        foreach (var e in enemiesViews)
        {

            if (e != null) 
            {
                e.ClearCharacter();
                Destroy(e);
            } 
        }
        enemiesViews.Clear();
    }


    private void ShowEndBattleMessage(BattleEndResult battleEndResult)
    {
        if (battleEndResult != null)
        {
            experience.text = "Опыта получено: " + battleEndResult.experienceGained;
            itemsGrid.UpdateGrid(battleEndResult.loot, ItemCategory.Miscellaneous);
            endBattleMessage.SetActive(true);
        }
    }


}
