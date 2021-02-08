using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static TMPro.TMP_Dropdown;

public class HeroDropDown : MonoBehaviour
{
    public Id SelectedHero { get { return selectedHero; } }

    private List<Hero> availableHeroes;
    private Id selectedHero;
    [SerializeField] private TMP_Dropdown heroDropdown;
    [SerializeField] private Sprite defaultPortrait;
    [SerializeField] private string defaultName;
    [SerializeField] private Id defaultValue = new Id();


    private void OnEnable()
    {
        selectedHero = defaultValue;
        updateHeroesDropdown();
        EventSystem.Instance.AddEventListener<Event_HeroStateChanged>(OnHeroStateChange);

    }


    private void OnDisable()
    {
        EventSystem.Instance.RemoveEventListener<Event_HeroStateChanged>(OnHeroStateChange);
    }

    public void OnSelectHero(int i)
    {
        if (i != 0)
        {
            selectedHero = availableHeroes[i-1].Id; //в элементе dropdown всегда добавляется дополнительный placeholder
        }
        else
        {
            selectedHero = defaultValue;
        }
    }


    public void OnHeroStateChange(Event_HeroStateChanged e)
    {
        updateHeroesDropdown();
    }

    public void updateHeroesDropdown()
    {
        availableHeroes = HeroDataManager.Instance.GetHeroesByState(Hero.HeroState.tower);
        if (availableHeroes != null)
        {
            PopulateDropDown(availableHeroes);
        }
    }

    public void PopulateDropDown(List<Hero> heroes)
    {
        heroDropdown.ClearOptions();

        List<OptionData> options = new List<OptionData>();
        options.Add(new OptionData(defaultName, defaultPortrait));
        foreach (var h in heroes)
        {
            options.Add(new OptionData(h.EntityName, h.getPortrait()));
        }
        heroDropdown.AddOptions(options);
    }






}
